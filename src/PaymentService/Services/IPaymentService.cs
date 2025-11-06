using PaymentService.Dtos;

namespace PaymentService.Services
{
    public interface IPaymentService
    {
        Task<PaymentResultDto> MakePaymentAsync(PaymentCreateDto dto);
    }
}
