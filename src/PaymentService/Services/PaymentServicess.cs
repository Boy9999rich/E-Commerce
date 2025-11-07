using Microsoft.EntityFrameworkCore;
using PaymentService.Dtos;
using PaymentService.Entities;
using PaymentService.Persistence;

namespace PaymentService.Services
{
    public class PaymentServicess : IPaymentService
    {
        private readonly AppDbContext appDbContext;
        private readonly HttpClient notificationClient;

        public PaymentServicess(AppDbContext appDbContext, HttpClient notificationClient)
        {
            this.appDbContext = appDbContext;
            this.notificationClient = notificationClient;
        }

        public async Task<PaymentResultDto> MakePaymentAsync(PaymentCreateDto dto)
        {
            // 1. Bazaga yozish
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                UserId = dto.UserId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                Status = "Paid"
            };
            appDbContext.Payments.Add(payment);
            await appDbContext.SaveChangesAsync();





            //// 2. OrderService'ga status update yuborish (HTTP orqali)
            //// (masalan: PUT /api/orders/{id}/status)
            //// ...

            // 3. NotificationService’ga yuborish
            await notificationClient.PostAsJsonAsync("api/notifications/send", new
            {
                UserId = dto.UserId,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Message = $"To‘lov muvaffaqiyatli amalga oshirildi: {dto.Amount} so‘m"
            });

            return new PaymentResultDto(true, "To‘lov muvaffaqiyatli amalga oshirildi");
        }
    }
}
