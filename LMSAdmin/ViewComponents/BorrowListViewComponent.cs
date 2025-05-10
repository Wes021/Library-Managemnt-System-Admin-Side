using LMSAdmin.Models.IRepositories;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSAdmin.ViewComponents
{
    public class BorrowListViewComponent:ViewComponent
    {
        private readonly IBorrowRepository _borrowRepository;

        public BorrowListViewComponent(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            BorrowViewModel borrowViewModel = new()
            {
                Borrows = await _borrowRepository.GetCategoriesAsync()
            };

            return await Task.FromResult<IViewComponentResult>(View(borrowViewModel));
        }
    }
}
