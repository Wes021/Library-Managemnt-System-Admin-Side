namespace LMSAdmin.Models.IRepositories
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string Id);
    }
}
