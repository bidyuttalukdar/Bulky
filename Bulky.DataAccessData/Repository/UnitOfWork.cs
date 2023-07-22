using Bulky.DataAccessData.Data;
using Bulky.DataAccessData.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccessData.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            Category = new CategoryRepository(_db); 
        }

        public void save()
        {
            _db.SaveChanges();

            //throw new NotImplementedException();
        }
    }
}
