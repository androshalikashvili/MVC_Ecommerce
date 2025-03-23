using MVCEcommerce.Models;

namespace MVCEcommerce.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
