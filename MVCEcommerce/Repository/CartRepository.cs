using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Data;
using MVCEcommerce.Models;
using MVCEcommerce.Repository.IRepository;

namespace MVCEcommerce.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await _context.CartItems.Include(ci => ci.Product).ToListAsync();
        }

        public async Task<CartItem?> GetCartItemByIdAsync(int id)
        {
            //return await _context.CartItems.FindAsync(id);
            return await _context.CartItems.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync()
        {
            _context.CartItems.RemoveRange(_context.CartItems);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CartItem?> GetCartItemByProductIdAsync(int productId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId);
        }

    }
}
