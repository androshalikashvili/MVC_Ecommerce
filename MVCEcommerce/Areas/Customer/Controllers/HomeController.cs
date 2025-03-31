using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCEcommerce.Models;
using MVCEcommerce.Models.ViewModels;
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
    public IActionResult Index(ProductFilterViewModel filter)
    {
        var products = _unitOfWork.Product.GetAll(includeProperties: "Category")
            .Select(p => new ProductViewModel
            {
                Product = p,
                Reviews = _unitOfWork.Review.GetReviewsByProductId(p.Id),
                AverageRating = _unitOfWork.Review.GetReviewsByProductId(p.Id).Any()
                    ? _unitOfWork.Review.GetReviewsByProductId(p.Id).Average(r => r.Rating)
                    : 0
            })
            .ToList();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            products = products.Where(p => p.Product.Name.ToLower().Contains(filter.Name.ToLower())).ToList();
        }

        if (filter.CategoryId.HasValue)
        {
            products = products.Where(p => p.Product.CategoryId == filter.CategoryId).ToList();
        }

        if (filter.MinPrice.HasValue)
        {
            products = products.Where(p => p.Product.Price >= filter.MinPrice).ToList();
        }

        if (filter.MaxPrice.HasValue)
        {
            products = products.Where(p => p.Product.Price <= filter.MaxPrice).ToList();
        }

        if (filter.Rating.HasValue)
        {
            products = products.Where(p => p.AverageRating >= filter.Rating).ToList();
        }

        var model = new ProductListViewModel
        {
            Products = products,
            Filter = filter
        };

        ViewBag.Categories = _unitOfWork.Category.GetAll().ToList();
        ViewBag.SearchTerm = filter.Name;

        return View(model);
    }



    //public IActionResult Index()
    //{
    //    var products = _unitOfWork.Product.GetAll(includeProperties: "Category")
    //        .Select(p => new ProductViewModel
    //        {
    //            Product = p,
    //            AverageRating = _unitOfWork.Review.GetReviewsByProductId(p.Id).Any()
    //                ? _unitOfWork.Review.GetReviewsByProductId(p.Id).Average(r => r.Rating)
    //                : 0
    //        })
    //        .ToList();

    //    return View(products);
    //}

    //public IActionResult Index()
    //{
    //    IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
    //    return View(productList);
    //}
    public IActionResult Details(int productId)
    {
        var product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category");
        var reviews = _unitOfWork.Review.GetReviewsByProductId(productId);
        if (product == null) return NotFound();

        var productViewModel = new ProductViewModel
        {
            Product = product,
            Reviews = reviews,
            CategoryList = _unitOfWork.Category
                .GetAll()
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }),
        };

        return View(productViewModel);
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
