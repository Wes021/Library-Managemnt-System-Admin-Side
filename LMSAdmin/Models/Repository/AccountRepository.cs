using LMSAdmin.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace LMSAdmin.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string Id)
        {
           
                var user =await _userManager.FindByIdAsync(Id);

            return user;
         }
    }
}
