using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Models;

namespace MVCEcommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 4, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 1 },
                new Category { Id = 3, Name = "History", DisplayOrder = 1 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100, CategoryId = 2, ImageUrl = "" },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200, CategoryId = 3, ImageUrl = "" },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300, CategoryId = 4, ImageUrl = "" }
                );
        }
    }
}
