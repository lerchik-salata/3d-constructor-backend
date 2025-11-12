using Microsoft.AspNetCore.Identity;
using ConstructorApi.Models;
using ConstructorApi.DTOs.Auth;
using System.Security.Claims;  
using Microsoft.AspNetCore.Authorization;


namespace ConstructorApi.Services
{

    public interface IAuthService
    {
        Task<(bool Success, IEnumerable<string> Errors)> RegisterAsync(RegisterDto dto);
        Task<(bool Success, string? Token, string? ErrorMessage)> LoginAsync(LoginDto dto);
        Task<ApplicationUser?> GetCurrentUserAsync(ClaimsPrincipal userPrincipal);
    }
    
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenService _jwtService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtTokenService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description));

            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));

            await _userManager.AddToRoleAsync(user, "User");

            return (true, Enumerable.Empty<string>());
        }

        public async Task<(bool Success, string? Token, string? ErrorMessage)> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return (false, null, "Invalid credentials");

            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
                return (false, null, "Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return (true, token, null);
        }
        
         public async Task<ApplicationUser?> GetCurrentUserAsync(ClaimsPrincipal userPrincipal)
        {
            if (userPrincipal == null) return null;
            return await _userManager.GetUserAsync(userPrincipal);
        }
    }
}
