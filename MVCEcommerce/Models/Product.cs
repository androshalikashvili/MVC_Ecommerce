using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEcommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        
        [Range(1, 10000)]
        public decimal Price { get; set; }
        public int? Rating { get; set; }

        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
