using UserService.Dtos;

namespace UserService.Services
{
    public class AuthService : IAuthService
    {
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

        public Task<long> SignUpUserAsync(UserRegisterDto userCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
