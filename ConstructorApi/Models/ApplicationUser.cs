using Microsoft.AspNetCore.Identity;

namespace ConstructorApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
