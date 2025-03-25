using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models;
using MVCEcommerce.Repository.IRepository;
using System.Linq.Expressions;

namespace MVCEcommerce.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        public void Update(Review obj)
        {
            obj.UpdatedAt = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;


            //var objFromDb = _context.Reviews.FirstOrDefault(u => u.Id == obj.Id);
            //if(objFromDb != null)
            //{
            //    objFromDb.Name = obj.Name;
            //    objFromDb.Comment = obj.Comment;
            //    objFromDb.Rating = obj.Rating;


            //}
        }
    }
}
