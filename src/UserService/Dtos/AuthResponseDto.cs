namespace UserService.Dtos
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
        public string TokenType { get; set; } = "Bearer";

        // Optional: foydalanuvchi haqida qisqa info
        public long UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
