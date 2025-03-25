namespace MVCEcommerce.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IReviewRepository Review { get; }
        void Save();
    }
}
