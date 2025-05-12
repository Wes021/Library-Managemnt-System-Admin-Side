using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LMSAdmin.Models.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private readonly LMSV2Context _lMSV2Context;

        public StatsRepository(LMSV2Context lMSV2Context)
        {
            _lMSV2Context = lMSV2Context;
        }

        public async Task<StatsViewModel> GetStats()
        {
            var result = new StatsViewModel();

            using (SqlConnection conn = new SqlConnection(_lMSV2Context.Database.GetConnectionString()))
            {
                using(SqlCommand sc= new SqlCommand("stats", conn))
                {
                   await conn.OpenAsync();

                    using(SqlDataReader sdr= await sc.ExecuteReaderAsync())
                    {
                        while (await sdr.ReadAsync())
                        {
                            result = new()
                            {
                                BooksCount=sdr.GetInt32(sdr.GetOrdinal("total_books")),
                                BorrowsCount=sdr.GetInt32(sdr.GetOrdinal("total_borrows")),
                                UsersCount=sdr.GetInt32(sdr.GetOrdinal("total_users"))
                            };
                        }
                    }
                }
            }

            return result;
        }

        
    }
}
