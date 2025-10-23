using System.Data;

namespace UserService.Entity
{
    public class User
    {
        public long UserId { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; } 
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public bool IsActive { get; set; } = true;

        public long RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
