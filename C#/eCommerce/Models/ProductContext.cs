using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models
{
    public class ProductContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. 'DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { }
    }
}