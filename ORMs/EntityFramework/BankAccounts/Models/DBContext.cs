using Microsoft.EntityFrameworkCore;
namespace BankAccounts.Models
{
    public class BankAccountsContext : DbContext 
    { 
        public BankAccountsContext(DbContextOptions options) : base(options) { }

        // ================================== User Table
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}