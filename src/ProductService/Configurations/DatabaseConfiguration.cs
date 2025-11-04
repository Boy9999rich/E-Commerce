using Microsoft.EntityFrameworkCore;
using ProductServic.Persistence;

namespace ProductServic.Configurations
{
    public static class DatabaseConfiguration
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
