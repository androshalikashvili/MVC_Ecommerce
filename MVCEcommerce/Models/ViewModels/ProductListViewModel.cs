using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

//namespace MVCEcommerce.Models.ViewModels
//{
//    public class ProductListViewModel
//    {
//        public IEnumerable<Product> Products { get; set; } = new List<Product>();
//        public ProductFilterViewModel Filter { get; set; } = new ProductFilterViewModel();
//    }

//}
namespace MVCEcommerce.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public ProductFilterViewModel Filter { get; set; } = new ProductFilterViewModel();
    }
}
