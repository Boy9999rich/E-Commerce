using PaymentService.Services;

namespace PaymentService.Configurations
{
    public static class DIConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPaymentService, PaymentServicess>();
        }
    }
}
