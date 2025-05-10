using LMSAdmin.Models;
using Microsoft.AspNetCore.Identity;

namespace LMSAdmin.ViewModel
{
    public class UserViewModel
    {
        public List<ApplicationUser> Users { get; set; }
    }
}
