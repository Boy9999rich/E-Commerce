using NotificationService.Dtos;

namespace NotificationService.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationCreateDto dto);
        Task SendSmsAsync(SmsCreateDto dto);
    }
}
