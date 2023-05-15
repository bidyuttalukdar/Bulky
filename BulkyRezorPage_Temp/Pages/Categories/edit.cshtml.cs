using BulkyRezorPage_Temp.Dataa;
using BulkyRezorPage_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRezorPage_Temp.Pages.Categories
{
    public class editModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Category? category { get; set; }
        public editModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null && id !=0)
            {
                category = _db.categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return Page();
        }
    }
}
