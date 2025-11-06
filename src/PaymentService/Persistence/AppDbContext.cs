using Microsoft.EntityFrameworkCore;
using PaymentService.Entities;
using PaymentService.EntityConfiguration;

namespace PaymentService.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
