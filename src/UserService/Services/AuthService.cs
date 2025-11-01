using Google.Apis.Auth;
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

        public async Task<LoginResponseDto> GoogleLoginAsync(GoogleAuthDto dto)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(dto.IdToken, new GoogleJsonWebSignature.ValidationSettings());

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.GoogleId == payload.Subject);

            if (user == null)
            {
                await GoogleRegisterAsync(dto);
                user = await _dbContext.Users.FirstOrDefaultAsync(u => u.GoogleId == payload.Subject);
            }

            var userTokenDto = new UserTokenDto
            {
                UserId = user.UserId,
                UserName = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.Name
            };

            var token = _tokenService.GenerateToken(userTokenDto);

            var loginResponseDto = new LoginResponseDto
            {
                AccessToken = token,
            };

            return loginResponseDto;
        }

        public async Task<long> GoogleRegisterAsync(GoogleAuthDto dto)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new List<string>
        {
              "407408718192.apps.googleusercontent.com" // shu joyni to‘g‘ri yoz
        }
            };



            var payload = await GoogleJsonWebSignature.ValidateAsync(dto.IdToken, new GoogleJsonWebSignature.ValidationSettings());

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.GoogleId == payload.Subject);

            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "User");
            if (role == null)
                throw new Exception("User roli topilmadi!");

            if (user != null)
            {
                return user.UserId;
            }

            user = new User
            {
                Username = payload.Email.Split('@')[0],
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                Email = payload.Email,
                EmailConfirmed = payload.EmailVerified,
                GoogleId = payload.Subject,
                GoogleProfilePicture = payload.Picture,
                RoleId = role.Id,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
        {
            if (userLoginDto == null)
                throw new ArgumentNullException(nameof(userLoginDto));

            var user = await _dbContext.Users
         .Include(u => u.Role) // agar role kerak bo'lsa
         .FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);

            if (user == null)
            {
                throw new Exception("UserName or password incorrect");
            }

            var checkUserPassword = PasswordHasher.Verify(userLoginDto.Password, user.PasswordHash, user.Salt);

            if (checkUserPassword == false)
            {
                throw new Exception("UserName or password incorrect");
            }

            var userTokenDto = new UserTokenDto
            {
                UserId = user.UserId,
                UserName = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.Name
            };

            var token = _tokenService.GenerateToken(userTokenDto);

            var loginResponseDto = new LoginResponseDto()
            {
                AccessToken = token,
            };

            return loginResponseDto;
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
