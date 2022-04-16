using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Models
{
    public class ProductsAndCategoriesContext : DbContext 
    { 
        public ProductsAndCategoriesContext(DbContextOptions options) : base(options) { }

        // ================================== User Table
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}