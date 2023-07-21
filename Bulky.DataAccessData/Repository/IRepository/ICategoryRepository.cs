using Bulky.ModelsData;

namespace Bulky.DataAccessData.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void save();
        void update(Category obj);
    }
}