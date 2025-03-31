using Microsoft.EntityFrameworkCore;

namespace MVCEcommerce.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICartRepository CartItem { get; }
        IReviewRepository Review { get; }
        void Save();
        Task SaveAsync();
    }
}
