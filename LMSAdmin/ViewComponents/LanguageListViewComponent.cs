using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.ViewComponents
{
    public class LanguageListViewComponent: ViewComponent
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageListViewComponent(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            LanguageViewModel languageViewModel = new()
            {
                languages = (await _languageRepository.GetLanguagesAsync()).ToList()
            };

            return await Task.FromResult<IViewComponentResult>(View(languageViewModel));
        }
    }
}
