using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _db.categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name can't be same with display order");
            }
 
            if (ModelState.IsValid) // Will check whether it is valid or not
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Post is created successfully";
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index"); 

            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.categories.Find(id);
            //Category? categoryFromDB1 = _db.categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDB2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        { 
            //while updatng make sure tht obj or id should not 0 basically id should come or populated if not it will create a new record to make sure that we should hide id by <input asp-for="Id" hidden> 

            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.categories.Find(id);
            //Category? categoryFromDB1 = _db.categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDB2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? categoryFromDb = _db.categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _db.categories.Remove(categoryFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
