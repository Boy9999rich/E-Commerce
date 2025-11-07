namespace NotificationService.Entities
{
    public class Notification
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
