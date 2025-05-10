namespace LMSAdmin.Models.IRepositories
{
    public interface IBorrowRepository
    {
        Task<List<Borrowing>> GetCategoriesAsync();
    }
}
