using Microsoft.EntityFrameworkCore;
using NotificationService.Persistence;

namespace NotificationService.Configurations
{
    public static class DatabaseConfiguatation
    {
        public static void ConfigureDB(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(connectionString));

           
        }
    }
}
