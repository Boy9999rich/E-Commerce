using PaymentService.Persistence;
using PaymentService.Services;

namespace PaymentService.Configurations
{
    public static class DIConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            var notificationUrl = builder.Configuration.GetValue<string>("ServiceUrls:Notification");

            builder.Services.AddHttpClient("NotificationClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServiceUrls:Notification"));
            })
             .ConfigurePrimaryHttpMessageHandler(() =>
                 new HttpClientHandler
                 {
                     ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                 });

            // PaymentService ni DI ga qo'shish, HttpClientFactory orqali uzatish
            builder.Services.AddScoped<IPaymentService, PaymentServicess>(sp =>
            {
                var dbContext = sp.GetRequiredService<AppDbContext>();
                var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                var client = httpClientFactory.CreateClient("NotificationClient");

                return new PaymentServicess(dbContext, client);
            });

        }
    }
}
