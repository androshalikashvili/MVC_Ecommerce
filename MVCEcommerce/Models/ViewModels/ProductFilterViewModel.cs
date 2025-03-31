using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVCEcommerce.Models.ViewModels
{
    public class ProductFilterViewModel
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Rating { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
