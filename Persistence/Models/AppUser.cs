using Microsoft.AspNetCore.Identity;

namespace Persistence.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string ApiToken { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
