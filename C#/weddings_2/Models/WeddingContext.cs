using Microsoft.EntityFrameworkCore;
namespace weddings_2.Models
{
    public class WeddingContext : DbContext {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }

        public DbSet<User> Users {get; set;}
        public DbSet<Wedding> Weddings {get; set;}
        public DbSet<Guest> Guests {get; set;}
    }
}