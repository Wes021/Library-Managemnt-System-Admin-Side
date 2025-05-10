using LMSAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMSAdmin.ViewModel
{
    public class AddBookViewModel
    {
        
        public IEnumerable<SelectListItem>? categories { get; set; }
        public IEnumerable<SelectListItem>? languages { get; set; }
        public IEnumerable<SelectListItem>? statues { get; set; }
        public Book Book { get; set; }
    }
}
