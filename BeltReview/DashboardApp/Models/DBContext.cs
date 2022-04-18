using Microsoft.EntityFrameworkCore;
namespace DashboardApp.Models
{
    public class DashboardAppContext : DbContext 
    { 
        public DashboardAppContext(DbContextOptions options) : base(options) { }

        // ================================== User Table
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}