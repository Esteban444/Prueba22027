using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;

namespace EasyStay.Contracts.Services
{
    public interface IAccountService
    {
        public Task<AuthResponseDto> Login(LoginRequestDto request);
        public Task<RegisterResponseDto> Register(RegisterUserRequestDto request);
    }
}
