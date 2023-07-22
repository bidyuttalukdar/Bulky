using Bulky.ModelsData;

namespace Bulky.DataAccessData.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void update(Category obj);
    }
}