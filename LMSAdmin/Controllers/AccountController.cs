using LMSAdmin.Models;
using LMSAdmin.Models.IRepositories;
using LMSAdmin.Models.Repository;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMSAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository, UserManager<ApplicationUser> userManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string Id)
        {
            var user = await _accountRepository.GetUserByIdAsync(Id);
           
            return View(user);
        }
    }
}
