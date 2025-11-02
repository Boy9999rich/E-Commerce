using GateWayApi.Dtos;

namespace GateWayApi.Services
{
    public interface IUserApiService
    {
        Task<long> RegisterUserAsync(RegisterDto registerDto);
        Task<LoginResponseDto> LoginUserAsync(LoginDto loginDto);
    }
}
