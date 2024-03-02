using Microsoft.AspNetCore.Identity;

namespace Pharamcy.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
