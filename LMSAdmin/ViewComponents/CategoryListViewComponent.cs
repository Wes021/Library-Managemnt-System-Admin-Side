using LMSAdmin.Models.IRepositories;
using LMSAdmin.Models.Repository;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.ViewComponents
{
    public class CategoryListViewComponent: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryListViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CategoryViewModel categoryViewModel = new()
            {
                Categories = (await _categoryRepository.GetCategoriesAsync()).ToList()
            };

            return await Task.FromResult<IViewComponentResult>(View(categoryViewModel));
        }
    }
}
