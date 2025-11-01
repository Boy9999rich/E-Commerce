using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService UserService;

        public AuthController(IAuthService userService)
        {
            UserService = userService;
        }

        [HttpPost("register")]

        public async Task<long> Register(UserRegisterDto userCreateDto)
        {
            return await UserService.SignUpUserAsync(userCreateDto);
        }

        [HttpPost("login")]
        public async Task<LoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            return await UserService.LoginUserAsync(userLoginDto);
        }

        [HttpPost("google/register")]
        public async Task<long> GoogleRegister(GoogleAuthDto googleAuthDto)
        {
            return await UserService.GoogleRegisterAsync(googleAuthDto);
        }

        [HttpPost("google/login")]
        public async Task<LoginResponseDto> GoogleLogin(GoogleAuthDto googleAuthDto)
        {
            return await UserService.GoogleLoginAsync(googleAuthDto);
        }
    }
}
