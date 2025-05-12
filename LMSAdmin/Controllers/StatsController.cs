using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMSAdmin.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatsRepository _statsRepository;

        public StatsController(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var statsviewmodel = new StatsViewModel
        //    {
        //        BooksCount =await _statsRepository.GetBooksCount()
        //    };
        //    return View(statsviewmodel);
        //}
    }
}
