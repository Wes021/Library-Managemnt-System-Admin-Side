using System.Diagnostics;
using LMSAdmin.Models;
using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStatsRepository _statsRepository;


        public HomeController(ILogger<HomeController> logger, IStatsRepository statsRepository)
        {
            _logger = logger;
            _statsRepository = statsRepository;
        }

       

        

        public async Task<IActionResult> Index()
        {
            var statsviewmodel = await _statsRepository.GetStats();
            return View(statsviewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
