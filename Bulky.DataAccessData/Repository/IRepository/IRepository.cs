using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccessData.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - > Category or any other model that we can want to interact with DB
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T,bool>> filter, string? includeProperties = null);  // by only id we might not like to retrieved
        void Add(T entity);
        //void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
