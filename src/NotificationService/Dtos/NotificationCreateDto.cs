namespace NotificationService.Dtos
{
    public class NotificationCreateDto
    {
        public long UserId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Message { get; set; } = default!;

    }
}
