namespace NotificationService.Dtos
{
    public class SmsCreateDto
    {
        public string PhoneNumber { get; set; } = null!;
        public string Message { get; set; } = null!;
        public long? UserId { get; set; }
        public long? OrderId { get; set; }

    }
}
