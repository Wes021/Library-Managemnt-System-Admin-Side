using LMSAdmin.Models;
using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LMSAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayCategories()
        {
            
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryRepository.AddCategory(category);

            return RedirectToAction(nameof(DisplayCategories));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var Category=await _categoryRepository.GetCategoryByIdAsync(id);

            return View(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
           await _categoryRepository.UpdateCategory(category);

            return RedirectToAction(nameof(DisplayCategories));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.DeleteCategory(id);

            return RedirectToAction(nameof(DisplayCategories));
        }
    }
}
