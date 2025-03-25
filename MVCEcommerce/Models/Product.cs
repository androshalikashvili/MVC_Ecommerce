using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0.01, 10000)]
        [Column(TypeName = "decimal(18, 2)")]

        public decimal Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
    }

}
