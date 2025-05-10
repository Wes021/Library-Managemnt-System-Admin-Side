using LMSAdmin.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LMSAdmin.Models.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly LMSV2Context _lMSV2Context;

        public BorrowRepository(LMSV2Context lMSV2Context)
        {
            _lMSV2Context = lMSV2Context;
        }

        public async Task<List<Borrowing>> GetCategoriesAsync()
        {
            List<Borrowing> borrowings = new(); 
            using (SqlConnection conn = new SqlConnection(_lMSV2Context.Database.GetConnectionString()))
            {
                await conn.OpenAsync();
                using (SqlCommand sc=new SqlCommand("GetBorrows", conn))
                {
                    sc.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sdr = await sc.ExecuteReaderAsync())
                    {
                       

                        while (await sdr.ReadAsync())
                        {
                          Borrowing borrows = new()
                            {
                                BorrowId=sdr.GetInt32(sdr.GetOrdinal("borrow_id")),
                                UserId=sdr.GetString(sdr.GetOrdinal("user Id")),
                                BookId=sdr.GetInt32(sdr.GetOrdinal("book_id")),
                              BorrowedAt = sdr.IsDBNull(sdr.GetOrdinal("borrowed_at")) ? (DateTime?)null : sdr.GetDateTime(sdr.GetOrdinal("borrowed_at")),

                              ReturnAt = sdr.IsDBNull(sdr.GetOrdinal("return_at"))
    ? (DateTime?)null
    : sdr.GetDateTime(sdr.GetOrdinal("return_at")),

                              FineAmount = sdr.GetDecimal(sdr.GetOrdinal("fine_amount")),
                                User=new ApplicationUser
                                {
                                    //Name=sdr.GetString(sdr.GetOrdinal("name")),
                                    Email=sdr.GetString(sdr.GetOrdinal("email")),
                                },
                                Book=new Book
                                {
                                    BookTitle=sdr.GetString(sdr.GetOrdinal("BookTitle")),

                                },

                                BorrowStatus=new BorrowStatus
                                {
                                    BorrowStatus1=sdr.GetString(sdr.GetOrdinal("BorrowStatus"))
                                }

                            };
                            borrowings.Add(borrows);
                        }

                    }
                }
            }

            return borrowings;
        }
    }
}
