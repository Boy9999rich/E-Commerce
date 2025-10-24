using UserService.Dtos;

namespace UserService.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> GoogleLoginAsync(GoogleAuthDto dto);
        Task<long> GoogleRegisterAsync(GoogleAuthDto dto);
        Task<long> SignUpUserAsync(UserRegisterDto userCreateDto);
        Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto);
    }
}
