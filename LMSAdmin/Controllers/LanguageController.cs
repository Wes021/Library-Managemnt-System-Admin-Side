using LMSAdmin.Models;
using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Language language)
        {
           await _languageRepository.AddLanguageAsync(language);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var language = await _languageRepository.GetLanguageByIdAsync(id);
            return View(language);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Language language)
        {
            await _languageRepository.UpdateLanguage(language);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _languageRepository.DeleteLanguage(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
