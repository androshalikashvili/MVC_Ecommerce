using MVCEcommerce.Models;

namespace MVCEcommerce.Repository.IRepository
{
    public interface ICartRepository
    {
        Task<CartItem?> GetCartItemByProductIdAsync(int productId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task<CartItem?> GetCartItemByIdAsync(int id);
        Task AddToCartAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task RemoveFromCartAsync(int id);
        Task ClearCartAsync();
        Task SaveAsync();
    }
}
