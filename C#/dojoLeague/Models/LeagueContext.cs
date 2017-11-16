using Microsoft.EntityFrameworkCore;

namespace dojoLeague.Models
{
    public class LeagueContext : DbContext
    {
        //include all models as DbSets ie. public DbSet<Guest> Guests {get; set;}
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Dojo> Dojos { get; set; }
        public LeagueContext(DbContextOptions<LeagueContext> options) : base(options)
        { }
    }
}