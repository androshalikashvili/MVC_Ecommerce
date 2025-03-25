using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models;
using MVCEcommerce.Repository.IRepository;

namespace MVCEcommerce.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
        return View(productList);
    }
    public IActionResult Details(int productId)
    {
        Product product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category, Reviews");
        return View(product);
    }

    public IActionResult AddReview(Review review)
    {
        _unitOfWork.Review.Add(review);
        _unitOfWork.Save();
        return RedirectToAction("Details", new { productId = review.ProductId });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
