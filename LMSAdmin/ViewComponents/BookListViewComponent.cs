using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.Components
{
    // Renamed the namespace to avoid conflict with the 'ViewComponent' type
    public class BookListViewComponent : ViewComponent
    {
        private readonly IBookRepository _bookRepository;

        public BookListViewComponent(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            BookViewModelClass bookViewModelClass = new()
            {
                Books = await _bookRepository.GetBooksAsync()
            };
            

            return await Task.FromResult<IViewComponentResult>(View(bookViewModelClass)); 
        }
    }
}
