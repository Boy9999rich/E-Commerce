using NotificationService.Services;

namespace NotificationService.Configurations
{
    public static class DIConfiguration 
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<INotificationService, NotificationServicess>();
        }
    }
}
