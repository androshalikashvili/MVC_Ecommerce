namespace MVCEcommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalPrice => Items.Sum(i => i.Product.Price * i.Quantity);
    }
}
