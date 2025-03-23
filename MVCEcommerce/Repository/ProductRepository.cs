using MVCEcommerce.Data;
using MVCEcommerce.Models;
using MVCEcommerce.Repository.IRepository;
using System.Linq.Expressions;

namespace MVCEcommerce.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product obj)
        {
            _context.Products.Update(obj);
        }
    }
}
