
using FluentValidation;
using FluentValidation.AspNetCore;

namespace UserService.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static void ConfigureFluentValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        }
    }
}
