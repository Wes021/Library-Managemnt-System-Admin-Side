using LMSAdmin.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LMSV2Context _lMSV2Context;

        public CategoryRepository(LMSV2Context lMSV2Context)
        {
            _lMSV2Context = lMSV2Context;
        }

        public async Task<int> AddCategory(Category category)
        {
            bool checkCategory = await _lMSV2Context.Categories.AnyAsync(c => c.CategoryN == category.CategoryN);

            if (checkCategory)
            {
                throw new Exception("Category already exist");
            }

            _lMSV2Context.Categories.Add(category);
            return await _lMSV2Context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int id)
        {
            var AnyBooks = _lMSV2Context.Books.Any(c => c.Category == id);

            if (AnyBooks)
            {
                throw new Exception("There is books in this category, Delete the book firt or cahnge the category");
            }

            var categoryTodelete = _lMSV2Context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

            if (categoryTodelete!=null)
            {
                _lMSV2Context.Categories.Remove(await categoryTodelete);
                return await _lMSV2Context.SaveChangesAsync(); 
             }

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _lMSV2Context.Categories.OrderBy(c => c.CategoryId).ToListAsync();
        }


        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _lMSV2Context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }


        public async Task<int> UpdateCategory(Category category)
        {
            var categoryToUpdate =await _lMSV2Context.Categories.FirstOrDefaultAsync(c=>c.CategoryId==category.CategoryId);

            if (!(categoryToUpdate == null))
            {
                categoryToUpdate.CategoryN = category.CategoryN;
                

                _lMSV2Context.Categories.Update(categoryToUpdate);

                return await _lMSV2Context.SaveChangesAsync();
            }
            else
            {
                    throw new ArgumentException($"The category to update can't be found.");
            }
        }
    }
}
