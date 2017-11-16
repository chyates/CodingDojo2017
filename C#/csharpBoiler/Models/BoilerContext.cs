using Microsoft.EntityFrameworkCore;

namespace csharpBoiler.Models
{
    public class BoilerContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. DbSet<User> Users { get; set; }
        public DbSet<User> Users { get; set; }
        public BoilerContext(DbContextOptions<BoilerContext> options) : base(options)
        { }
    }
}

