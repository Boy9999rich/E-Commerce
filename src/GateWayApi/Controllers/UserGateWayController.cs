using GateWayApi.Dtos;
using GateWayApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGateWayController : ControllerBase
    {
        private readonly IUserApiService _userApiService;

        public UserGateWayController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        [HttpPost("register")]
        public async Task<long> Register([FromBody] UserRegisterDto registerDto)
        {
            var result = await _userApiService.RegisterUserAsync(registerDto);
            return result;
        }

        [HttpPost("login")]
        public async Task<LoginResponseDto> Login([FromBody] UserLoginDto loginDto)
        {
            var result = await _userApiService.LoginUserAsync(loginDto);
            return result;
        }
    }
}
