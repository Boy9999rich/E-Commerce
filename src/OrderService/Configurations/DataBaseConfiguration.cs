using Microsoft.EntityFrameworkCore;
using OrderService.Persistence;

namespace OrderService.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void ConfigureDB(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            //var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(connectionString));

            //builder.Services.AddSingleton(jwtSettings);
        }
    }
}
