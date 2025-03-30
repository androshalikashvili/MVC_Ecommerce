using Microsoft.AspNetCore.Identity;

namespace MVCEcommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
