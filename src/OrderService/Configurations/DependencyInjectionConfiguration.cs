using OrderService.Services;

namespace OrderService.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IOrderService, OrderServicess>();
        }
    }
}
