using MVCEcommerce.Models;

namespace MVCEcommerce.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
