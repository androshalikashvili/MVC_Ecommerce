namespace MVCEcommerce.Models.ViewModels
{
    public class CartItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

    }
}
