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

            // 2. Notification Service'ga yuborish
            try
            {
                var notificationData = new
                {
                    UserId = dto.UserId,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Message = $"To'lov muvaffaqiyatli amalga oshirildi: {dto.Amount} so'm"
                };

                // HttpClient allaqachon base address bilan sozlangan, shuning uchun faqat relative path ishlatamiz
                var response = await notificationClient.PostAsJsonAsync("api/notification/send", notificationData);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ Notification yuborishda xatolik: {response.StatusCode}");
                    Console.WriteLine($"❌ Error content: {errorContent}");
                    // Xatolik bo'lsa ham, to'lov muvaffaqiyatli deb hisoblaymiz
                }
                else
                {
                    Console.WriteLine("✅ Notification muvaffaqiyatli yuborildi!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Notification yuborishda exception: {ex.Message}");
                // Xatolik bo'lsa ham, to'lov muvaffaqiyatli deb hisoblaymiz
            }

            return new PaymentResultDto(true, "To'lov muvaffaqiyatli amalga oshirildi");
        }
    }
}
