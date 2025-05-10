using LMSAdmin.ViewModel;

namespace LMSAdmin.Models.IRepositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();

        Task<int> AddBookAsync(Book book);

        Task<int> UpdateBook(Book book);

        Task<List<Book>> GetBookById(int id);

        Task<int> DeleteBook(int id);

    }
}
