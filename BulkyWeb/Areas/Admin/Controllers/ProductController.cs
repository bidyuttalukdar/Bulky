using Bulky.DataAccessData.Repository.IRepository;
using Bulky.ModelsData;
using Bulky.ModelsData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Web.Helpers;

namespace BulkyWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return View(productList);
        }

        public IActionResult Upsert(int? Id)
        {
            ProductVM productVM = new()
            {
                Product = new Product(),
                CategoryList = (IEnumerable<System.Web.Mvc.SelectListItem>)_unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            if(Id == null || Id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == Id,includeProperties: "Category");
                return View(productVM);
            }
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // to get the wwwRoot folder path
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    // to get file name and extension
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); 
                    string filePath = Path.Combine(wwwRootPath, @"images\product");
                    // if image exist delete that and add newly
                    if(!string.IsNullOrEmpty(productVM.Product.ImageURL) )
                    {
                        string oldImageUrl = Path.Combine(wwwRootPath, productVM.Product.ImageURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }
                    }

                    using(var fileStream = new FileStream(Path.Combine(filePath,fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageURL = @"images\product" + fileName; 

                }

                //check it is a create or update request
                if(productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.save();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                productVM.CategoryList = (IEnumerable<System.Web.Mvc.SelectListItem>)_unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
            
        }
        // No need as we combine create and edit

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDB = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? productFromDB1 = _db.categories.FirstOrDefault(u=>u.Id == id);
            //Product? productFromDB2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();

            if (productFromDB == null)
            {
                return NotFound();
            }

            return View(productFromDB);
        }
        // No need as we combine create and edit
        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.save();
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
            Product? productFromDB = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? productFromDB1 = _db.categories.FirstOrDefault(u=>u.Id == id);
            //Product? productFromDB2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();

            if (productFromDB == null)
            {
                return NotFound();
            }

            return View(productFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
