using MVCEcommerce.Models;

namespace MVCEcommerce.Repository.IRepository
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
        Task AddReviewAsync(Review review);
        IEnumerable<Review> GetReviewsByProductId(int productId);
    }
}
