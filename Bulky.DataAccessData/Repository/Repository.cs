﻿using System;
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

        }
        public void Add(T entity)
        {
            //throw new NotImplementedException();
            dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            //throw new NotImplementedException();
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            //throw new NotImplementedException();
            IQueryable<T> query = dbSet;
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
