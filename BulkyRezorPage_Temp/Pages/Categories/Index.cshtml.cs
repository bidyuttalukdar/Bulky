using BulkyRezorPage_Temp.Dataa;
using BulkyRezorPage_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRezorPage_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        
        public readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.categories.ToList();  
        }
    }
}
