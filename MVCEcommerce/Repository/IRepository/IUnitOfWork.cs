namespace MVCEcommerce.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICartRepository CartItem { get; }
        void Save();
    }
}
