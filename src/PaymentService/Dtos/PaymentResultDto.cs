namespace PaymentService.Dtos
{
    public class PaymentResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;

        public PaymentResultDto(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
