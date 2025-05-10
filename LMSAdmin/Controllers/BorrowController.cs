using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.Controllers
{
    public class BorrowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
