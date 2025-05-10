namespace LMSAdmin.Models.IRepositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<BookStatus>> GetStatusAsync();
    }
}
