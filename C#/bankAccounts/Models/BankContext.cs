using Microsoft.EntityFrameworkCore;

namespace bankAccounts.Models
{
    public class BankContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. public DbSet<User> Users { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        { }
    }
}