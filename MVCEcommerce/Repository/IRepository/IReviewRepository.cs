using MVCEcommerce.Models;

namespace MVCEcommerce.Repository.IRepository
{
    public interface IReviewRepository : IRepository<Review>
    {
        void Update(Review obj);
    }
}
