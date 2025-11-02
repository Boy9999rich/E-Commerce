using Microsoft.EntityFrameworkCore;
using ProductService.Entities;

namespace ProductService.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Users { get; set; }
    }
}
