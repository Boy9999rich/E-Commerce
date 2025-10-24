using UserService.Dtos;

namespace UserService.Services
{
    public interface ITokenService
    {
        public string GenerateToken(UserTokenDto tokenDto);
    }
}
