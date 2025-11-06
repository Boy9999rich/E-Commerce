namespace PaymentService.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string Status { get; set; } = "Pending"; // Pending, Paid, Failed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
