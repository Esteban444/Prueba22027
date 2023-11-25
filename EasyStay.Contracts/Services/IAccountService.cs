using EasyStay.Models.Dto;

namespace EasyStay.Contracts.Services
{
    public interface IAccountService
    {
        public Task<AuthResponseDto> Login(LoginRequestDto request);
        public Task<RegisterResponseDto> Register(RegisterUserDto request);
    }
}
