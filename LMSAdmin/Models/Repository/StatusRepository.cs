using LMSAdmin.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly LMSV2Context _lMSV2Context;

        public StatusRepository(LMSV2Context lMSV2Context)
        {
            _lMSV2Context = lMSV2Context;
        }

        public async Task<IEnumerable<BookStatus>> GetStatusAsync()
        {

            return await _lMSV2Context.BookStatuses.OrderBy(o=>o.StatusId).ToListAsync();
        }
    }
}
