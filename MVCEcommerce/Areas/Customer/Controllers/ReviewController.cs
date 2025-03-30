using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models;
using MVCEcommerce.Repository.IRepository;

namespace MVCEcommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AddReview(int productId)
        {
            var review = new Review { ProductId = productId };
            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(review);
            }

            await _unitOfWork.Review.AddReviewAsync(review);
            _unitOfWork.Save();

            TempData["success"] = "Отзыв добавлен!";
            return RedirectToAction("Details", "Product", new { id = review.ProductId });
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews(int productId)
        {
            var reviews = await _unitOfWork.Review.GetReviewsByProductIdAsync(productId);
            return PartialView("_ReviewsPartial", reviews);
        }
    }
}
