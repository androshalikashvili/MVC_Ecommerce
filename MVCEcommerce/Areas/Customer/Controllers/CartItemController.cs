using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Models;
using MVCEcommerce.Models.ViewModels;
using MVCEcommerce.Repositories;
using MVCEcommerce.Repository.IRepository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MVCEcommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/CartItem")]
    public class CartItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Displaying the cart  WORKED!!!!!!!!!!!!!
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var cartItems = await _unitOfWork.CartItem.GetCartItemsAsync();
            //var cartItems = await _cartRepository.GetCartItemsAsync();
            return View(cartItems);
        }

        // Adding a product to the cart  WORKED!!!!!!!!!!!!!
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(int productId, int quantity = 1)
        {
            if (productId <= 0)
            {
                return BadRequest("Неверный идентификатор товара.");
            }

            var existingItem = await _unitOfWork.CartItem.GetCartItemByProductIdAsync(productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _unitOfWork.CartItem.UpdateCartItemAsync(existingItem);
            }
            else
            {
                var newItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                };
                await _unitOfWork.CartItem.AddToCartAsync(newItem);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Remove/{id}")]
        public async Task<IActionResult>Remove(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }
            CartItem? productFromCart = await _unitOfWork.CartItem.GetCartItemByIdAsync(id);
            if (productFromCart == null)
            {
                return NotFound();
            }
            return View(productFromCart);
        }

        // Removing an item from the cart WORKED!!!!!!!!!!!!!
        [HttpPost("Remove/{id}")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            var cartItem = await _unitOfWork.CartItem.GetCartItemByIdAsync(id);
            if (cartItem == null)
            {
                return NotFound($"Product with ID {id} not found in cart.");
            }

            await _unitOfWork.CartItem.RemoveFromCartAsync(id);
            _unitOfWork.Save();
            TempData["success"] = "Product From Cart Deleted Successfully";
            return RedirectToAction("Index", "CartItem");
        }

        // Clear all items from the cart WORKED!!!!!!!!!!!!!
        [HttpPost("ClearCart")]
        public async Task<IActionResult> Clear()
        {
            await _unitOfWork.CartItem.ClearCartAsync();
            _unitOfWork.Save();
            TempData["success"] = "The basket has been emptied successfully.!";

            return RedirectToAction("Index", "Home");
        }

        // Updating the quantity of items in the cart  WORK!!!!!!!!!!!!
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            if (id <= 0 || quantity <= 0)
            {
                return BadRequest("Некорректные данные.");
            }

            var cartItem = await _unitOfWork.CartItem.GetCartItemByIdAsync(id);
            if (cartItem == null)
            {
                return NotFound($"Товар с ID {id} не найден в корзине.");
            }

            cartItem.Quantity = quantity;
            await _unitOfWork.CartItem.UpdateCartItemAsync(cartItem);

            return RedirectToAction("Index", "CartItem");
        }
    }
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T?) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
