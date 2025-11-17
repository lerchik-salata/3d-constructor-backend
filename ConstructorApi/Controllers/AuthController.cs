using Microsoft.AspNetCore.Mvc;
using ConstructorApi.DTOs.Auth;
using ConstructorApi.Services;
using System.Security.Claims;          
using Microsoft.AspNetCore.Authorization;

namespace ConstructorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(dto);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(new { message = "Registered" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (!result.Success)
                return Unauthorized(new { message = result.ErrorMessage });

            return Ok(new { token = result.Token });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _authService.GetCurrentUserAsync(User);
            if (user == null) return NotFound();

               var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
               var role = roleClaim?.Value ?? "User";

            return Ok(new 
            {
                user.Id,
                user.UserName,
                user.Email,
                Role = role
            });
        }

    }
}
