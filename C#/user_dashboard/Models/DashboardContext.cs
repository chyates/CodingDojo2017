using Microsoft.EntityFrameworkCore;

namespace user_dashboard.Models
{
    public class DashboardContext : DbContext
    {
        //include all models as DbSets ie. public DbSet<Guest> Guests {get; set;}
        public DbSet<User> Users {get; set;}
        public DashboardContext(DbContextOptions<DashboardContext> options) : base(options)
        { }
    }
}