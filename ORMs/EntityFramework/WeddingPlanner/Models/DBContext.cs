using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext 
    { 
        public WeddingPlannerContext(DbContextOptions options) : base(options) { }

        // ================================== User Table
        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
    }
}