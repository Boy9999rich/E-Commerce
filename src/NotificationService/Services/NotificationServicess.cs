using Microsoft.EntityFrameworkCore;
using NotificationService.Dtos;
using NotificationService.Entities;
using NotificationService.Persistence;
using System.Net;
using System.Net.Mail;

namespace NotificationService.Services
{
    public class NotificationServicess : INotificationService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public NotificationServicess(AppDbContext appDbContext, IConfiguration configuration)
        {
            this._context = appDbContext;
            this._config = configuration;
        }

        public async Task SendNotificationAsync(NotificationCreateDto dto)
        {
            // 1. Bazaga saqlash
            var notification = new Notification
            {
                UserId = dto.UserId,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Message = dto.Message
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            // 2. Email yuborish
            if (!string.IsNullOrEmpty(dto.Email))
            {
                var smtpClient = new SmtpClient(_config["Smtp:Host"])
                {
                    Port = int.Parse(_config["Smtp:Port"]!),
                    Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                    EnableSsl = true
                };

                var mail = new MailMessage
                {
                    From = new MailAddress(_config["Smtp:FromEmail"]!),
                    Subject = "To‘lov haqida bildirishnoma",
                    Body = dto.Message,
                    IsBodyHtml = false
                };
                mail.To.Add(dto.Email);

                await smtpClient.SendMailAsync(mail);
            }

            // 3. Telefon raqamga SMS (shunchaki log uchun)
            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                Console.WriteLine($"📱 SMS yuborildi: {dto.PhoneNumber} => {dto.Message}");
            }
        }

        public Task SendSmsAsync(SmsCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
