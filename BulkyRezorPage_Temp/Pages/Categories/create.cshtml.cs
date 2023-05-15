using BulkyRezorPage_Temp.Dataa;
using BulkyRezorPage_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRezorPage_Temp.Pages.Categories
{
    public class createModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Category category { get; set; }
        public createModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() { 
            _db.categories.Add(category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
