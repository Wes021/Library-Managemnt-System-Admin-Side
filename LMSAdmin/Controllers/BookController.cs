using LMSAdmin.Models;
using LMSAdmin.Models.IRepositories;
using LMSAdmin.Models.Repository;
using LMSAdmin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace LMSAdmin.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookController(ICategoryRepository categoryRepository, IBookRepository bookRepository, ILanguageRepository languageRepository, IStatusRepository statusRepository, UserManager<ApplicationUser> userManager)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _statusRepository = statusRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Add()
        {
            var allCategories =await _categoryRepository.GetCategoriesAsync();
            var allLanguages =await _languageRepository.GetLanguagesAsync();
            var allStatuses = await _statusRepository.GetStatusAsync();

            IEnumerable<SelectListItem> selectListCategories = new SelectList(allCategories, "CategoryId", "CategoryN", "select");
            IEnumerable<SelectListItem> selectListILanguages = new SelectList(allLanguages, "LanguageId", "LanguageN", null);
            IEnumerable<SelectListItem> selectListStatus = new SelectList(allStatuses, "StatusId", "BookStatusN", null);

            AddBookViewModel Lists = new()
            {
                categories = selectListCategories,
                languages = selectListILanguages,
                statues=selectListStatus
                
            };
            
            return View(Lists);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            Random r = new Random();
            Book newBook = new()
            {
                BookId = r.Next(1, 100),
                Isbn = addBookViewModel.Book.Isbn,
                Publisher = addBookViewModel.Book.Publisher,
                Language = addBookViewModel.Book.Language,
                Year = addBookViewModel.Book.Year,
                Category = addBookViewModel.Book.Category,
                Image = addBookViewModel.Book.Image,
                Status = addBookViewModel.Book.Status,
                CreatedAt = DateTime.Now,
                TotalCopies = addBookViewModel.Book.TotalCopies,
                FineRate=addBookViewModel.Book.FineRate,
                BookTitle = addBookViewModel.Book.BookTitle


            };

            await _bookRepository.AddBookAsync(newBook);
            return RedirectToAction(nameof(Add));
            
        }
        

        public async Task<IActionResult> Index()
        {

            
            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var allCategories = await _categoryRepository.GetCategoriesAsync();
            var allLanguages = await _languageRepository.GetLanguagesAsync();
            var allStatuses = await _statusRepository.GetStatusAsync();

            IEnumerable<SelectListItem> selectListCategories = new SelectList(allCategories, "CategoryId", "CategoryN", "select");
            IEnumerable<SelectListItem> selectListILanguages = new SelectList(allLanguages, "LanguageId", "LanguageN", null);
            IEnumerable<SelectListItem> selectListStatus = new SelectList(allStatuses, "StatusId", "BookStatusN", null);
            var books = await _bookRepository.GetBookById(id);
          
            AddBookViewModel addbookViewModelClass = new()
            {
                Book = books.FirstOrDefault(),
                categories = selectListCategories,
                languages = selectListILanguages,
                statues = selectListStatus
            };

            return View(addbookViewModelClass);
        }

        public async Task<IActionResult> Update(Book book)
        {
          await _bookRepository.UpdateBook(book);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bookRepository.DeleteBook(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
