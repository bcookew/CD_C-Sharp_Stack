using Microsoft.EntityFrameworkCore;
namespace TheWall.Models
{
    public class TheWallContext : DbContext 
    { 
        public TheWallContext(DbContextOptions options) : base(options) { }

        // ================================== User Table
        public DbSet<User> Users { get; set; }
    }
}