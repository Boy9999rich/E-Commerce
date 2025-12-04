using ProductServic.Services;
using ProductService.Services;

namespace ProductServic.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductService, ProductServicess>();
            builder.Services.AddScoped<IImageService, ImageService>();
        }
    }
}
