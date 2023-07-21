using Bulky.DataAccessData.Data;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public void save()
        {
            _db.SaveChanges();
            //   throw new NotImplementedException();
        }

        public void update(Category obj)
        {
            _db.categories.Update(obj);
            //throw new NotImplementedException();
        }
    }
}
