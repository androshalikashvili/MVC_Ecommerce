using MVCEcommerce.Data;
using MVCEcommerce.Models;
using MVCEcommerce.Repositories;
using MVCEcommerce.Repository.IRepository;

namespace MVCEcommerce.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category {  get; private set; }
        public IProductRepository Product {  get; private set; }
        public ICartRepository CartItem { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Product = new ProductRepository(_context);
            CartItem = new CartRepository(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
