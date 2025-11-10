
using UserService.Configurations;
using UserService.Configurations.Settings;
using UserService.Fluent_validation;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JWTSettings>();
            builder.Services.AddSingleton(jwtSettings);

            builder.ConfigureDB();
            builder.ConfigureDI();
            builder.ConfigureJwt();
            builder.ConfigureFluentValidation();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
