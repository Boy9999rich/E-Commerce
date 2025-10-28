using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UserService.Dtos;
using UserService.Entity;
using UserService.Persistence;

namespace UserService.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public Task<LoginResponseDto> GoogleLoginAsync(GoogleAuthDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<long> GoogleRegisterAsync(GoogleAuthDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<long> SignUpUserAsync(UserRegisterDto userRegisterDto)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email == userRegisterDto.Email))
                throw new InvalidOperationException("Bu email bilan foydalanuvchi allaqachon mavjud!");

            // Parolni hashlaymiz
            var passwordHash = PasswordHasher.Hasher(userRegisterDto.Password);

            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "User");
            if (role == null)
                throw new Exception("User roli topilmadi!");

            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                PasswordHash = passwordHash.Hash,
                Salt = passwordHash.Salt,
                RoleId = role.Id,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.UserId;
        }
    }
}
