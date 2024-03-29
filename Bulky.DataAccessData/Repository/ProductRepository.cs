﻿using Bulky.DataAccessData.Data;
using Bulky.DataAccessData.Repository.IRepository;
using Bulky.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccessData.Repository
{
    public class ProductRepository : Repository<Product> ,IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   

        public void Update(Product product)
        {
            var objFromDb =  _db.Products.Where(p => p.Id == product.Id).FirstOrDefault();
            if (objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;    
                objFromDb.ISBN = product.ISBN;
                objFromDb.Author = product.Author;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.ImageURL = product.ImageURL;
                if(product.ImageURL != null)
                {
                    objFromDb.ImageURL = product.ImageURL.ToString();
                }
            }
            _db.Products.Update(product);
        }
    }
}
