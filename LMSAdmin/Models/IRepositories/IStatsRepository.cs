using LMSAdmin.ViewModel;

namespace LMSAdmin.Models.IRepositories
{
    public interface IStatsRepository
    {
        Task<StatsViewModel> GetStats();
        
    }
}
