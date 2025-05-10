namespace LMSAdmin.Models.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<int> AddCategory(Category category);

        Task<int> UpdateCategory(Category category);

        Task<Category?> GetCategoryByIdAsync(int id);

        Task<int> DeleteCategory(int id);
    }
}
