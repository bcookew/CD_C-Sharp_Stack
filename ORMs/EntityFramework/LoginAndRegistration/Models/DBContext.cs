using Microsoft.EntityFrameworkCore;
namespace LoginAndRegistration.Models
{
    public class DBContext : DbContext 
    { 
        public DBContext(DbContextOptions options) : base(options) { }

        // ================================== User Table
        public DbSet<User> Users { get; set; }
    }
}