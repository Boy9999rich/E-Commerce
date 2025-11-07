using Microsoft.EntityFrameworkCore;
using NotificationService.Entities;
using NotificationService.Persistence.EntityConfiguration;

namespace NotificationService.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NotiificationConfiguration());
        }
    }
}
