using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Models
{
    public class MyAppContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Wedding> Weddings {get; set;}
        public DbSet<Guest> Guests {get; set;}
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        { }
    }
}