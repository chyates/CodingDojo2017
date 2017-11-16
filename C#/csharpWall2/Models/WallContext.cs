using Microsoft.EntityFrameworkCore;

namespace csharpWall2.Models
{
  public class WallContext : DbContext
  {
     //include all models as DbSets ie. public DbSet<Guest> Guests {get; set;}
    public WallContext(DbContextOptions<WallContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}