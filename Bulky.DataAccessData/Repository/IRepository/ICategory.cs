using Bulky.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccessData.Repository.IRepository
{
    public interface ICategory : IRepository<Category>
    {
        void update(Category obj);
        void save();
    }
}
