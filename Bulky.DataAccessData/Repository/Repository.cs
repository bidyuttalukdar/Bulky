using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccessData.Data;
using Bulky.DataAccessData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccessData.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //_db.Catgories == dbSet
            _db.Products.Include(u => u.Catgory).Include(u => u.CategoryId);

        }
        public void Add(T entity)
        {
            //throw new NotImplementedException();
            dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            //throw new NotImplementedException();
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            //throw new NotImplementedException();
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)) { 
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            //throw new NotImplementedException();
            dbSet.Remove(entity);   
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            //throw new NotImplementedException();
            dbSet.RemoveRange(entity);
        }
    }
}
