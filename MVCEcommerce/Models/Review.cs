using System.ComponentModel.DataAnnotations;

namespace MVCEcommerce.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }  // 1 - 5

        [Required, StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required, StringLength(500)]
        public string Content { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
