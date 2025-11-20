using UserService.Fluent_validation;
using UserService.Services;

namespace UserService.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddScoped<UserRegisterValidator, UserRegisterValidator>();
        }
    }
}
