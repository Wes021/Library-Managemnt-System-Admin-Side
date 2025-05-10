using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LMSAdmin.Models.Repository
{
    public class BookRepository:IBookRepository
    {
        
        
        private readonly LMSV2Context _lMSV2Context;
        public BookRepository(LMSV2Context lMSV2Context)
        {
            _lMSV2Context = lMSV2Context;
        }
        
        public async Task<int> AddBookAsync(Book book)
        {
            _lMSV2Context.Books.Add(book);
            

            return await _lMSV2Context.SaveChangesAsync();
            
            
        }

        public async Task<int> DeleteBook(int id)
        {
            var bookTodelete = await _lMSV2Context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (!(bookTodelete==null))
            {
                _lMSV2Context.Books.Remove(bookTodelete);

               return await _lMSV2Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The book to delete can't be found.");
            }
        }

        public async Task<List<Book>> GetBookById(int id)
        {
            List<Book> books = new();
            var book =await _lMSV2Context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            books.Add(book);
            return  books ;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            List<Book> books = new();
                
            

            using (SqlConnection conn = new SqlConnection(_lMSV2Context.Database.GetConnectionString()))
            {
                await conn.OpenAsync();

                using (SqlCommand sc = new SqlCommand("Getbooks", conn))
                {
                    sc.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader scd = await sc.ExecuteReaderAsync())
                    {
                        while (await scd.ReadAsync())
                        {
                            Book book = new()
                            {
                                BookId = scd.GetInt32(scd.GetOrdinal("book_id")),
                                Isbn = scd.GetInt32(scd.GetOrdinal("ISBN")),
                                Publisher = scd.IsDBNull(scd.GetOrdinal("Publisher")) ? null : scd.GetString(scd.GetOrdinal("Publisher")),
                                Year = scd.IsDBNull(scd.GetOrdinal("Year")) ? null : scd.GetInt32(scd.GetOrdinal("Year")),
                                Image = scd.IsDBNull(scd.GetOrdinal("Image")) ? null : scd.GetString(scd.GetOrdinal("Image")),
                                FineRate = scd.IsDBNull(scd.GetOrdinal("fine_rate")) ? null : scd.GetDecimal(scd.GetOrdinal("fine_rate")),
                                CreatedAt = scd.IsDBNull(scd.GetOrdinal("created_at")) ? null : scd.GetDateTime(scd.GetOrdinal("created_at")),
                                TotalCopies = scd.IsDBNull(scd.GetOrdinal("total_copies")) ? null : scd.GetString(scd.GetOrdinal("total_copies")),
                                BookTitle = scd.IsDBNull(scd.GetOrdinal("BookTitle")) ? null : scd.GetString(scd.GetOrdinal("BookTitle")),
                                LanguageNavigation = scd.IsDBNull(scd.GetOrdinal("Language")) ? null : new Language
                                {
                                   
                                    LanguageN = scd.GetString(scd.GetOrdinal("Language"))
                                },
                                StatusNavigation = scd.IsDBNull(scd.GetOrdinal("Book_status")) ? null : new BookStatus
                                {
                                    BookStatusN = scd.GetString(scd.GetOrdinal("Book_status"))
                                },
                                CategoryNavigation = scd.IsDBNull(scd.GetOrdinal("Category")) ? null : new Category
                                {
                                    CategoryN = scd.GetString(scd.GetOrdinal("Category"))
                                }
                            };

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public async Task<int> UpdateBook(Book book)
        {
            var bookToupdate = await _lMSV2Context.Books.FirstOrDefaultAsync(b=>b.BookId==book.BookId);

            if (!(bookToupdate==null))
            {
                bookToupdate.BookTitle = book.BookTitle;
                bookToupdate.Status = book.Status;
                bookToupdate.Isbn = book.Isbn;
                bookToupdate.Publisher = book.Publisher;
                bookToupdate.Language = book.Language;
                bookToupdate.Year = book.Year;
                bookToupdate.Category = book.Category;
                bookToupdate.Image = book.Image;
                bookToupdate.Status = book.Status;
                bookToupdate.FineRate = book.FineRate;
                
                bookToupdate.TotalCopies = book.TotalCopies;

                _lMSV2Context.Books.Update(bookToupdate);

                return await _lMSV2Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The book to update can't be found.");
            }
        }
    }
}
