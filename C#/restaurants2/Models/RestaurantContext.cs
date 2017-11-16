using Microsoft.EntityFrameworkCore;

namespace restaurants2.Models
{
    public class RestaurantContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. 'DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        { }
    }
}