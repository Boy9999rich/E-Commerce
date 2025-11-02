using GateWayApi.Dtos;

namespace GateWayApi.Services
{
    public interface IUserApiService
    {
        Task<long> RegisterUserAsync(UserRegisterDto registerDto);
        Task<LoginResponseDto> LoginUserAsync(UserLoginDto loginDto);
    }
}
