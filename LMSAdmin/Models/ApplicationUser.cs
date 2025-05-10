using Microsoft.AspNetCore.Identity;

namespace LMSAdmin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public int? UserStatusId { get; set; }
    }
}
