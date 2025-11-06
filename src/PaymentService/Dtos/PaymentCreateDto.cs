namespace PaymentService.Dtos
{
    public class PaymentCreateDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
