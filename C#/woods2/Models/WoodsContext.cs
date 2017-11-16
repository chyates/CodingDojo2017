using Microsoft.EntityFrameworkCore;

namespace woods2.Models
{
  public class WoodsContext : DbContext
  {
     //include all models as DbSets ie. public DbSet<Guest> Guests {get; set;}
     public DbSet<Trail> Trails {get; set; }
  public WoodsContext(DbContextOptions<WoodsContext> options) : base(options)
  { }
  }
}