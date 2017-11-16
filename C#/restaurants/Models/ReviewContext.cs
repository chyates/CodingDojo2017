using Microsoft.EntityFrameworkCore;

namespace restaurants.Models
{
  public class ReviewContext : DbContext
  {
  // base() calls the parent class' constructor passing the "options" parameter along
  public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) { }
  public DbSet<Review> Reviews {get; set;}
  }
}