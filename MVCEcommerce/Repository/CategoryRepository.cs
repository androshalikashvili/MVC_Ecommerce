using MVCEcommerce.Data;
using MVCEcommerce.Models;
using MVCEcommerce.Repository.IRepository;
using System.Linq.Expressions;

namespace MVCEcommerce.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category obj)
        {
            _context.Categories.Update(obj);
        }
    }
}
