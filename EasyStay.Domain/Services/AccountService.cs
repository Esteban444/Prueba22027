using AutoMapper;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Models.Dto;
using EasyStay.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyStay.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly JwtHandler _jwtHandler;
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<Users> userManager, IMapper mapper,JwtHandler jwtHandler)
        {
            this._jwtHandler = jwtHandler;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new Exception("The user does not exist.");

                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    await _userManager.AccessFailedAsync(user);

                    if (await _userManager.IsLockedOutAsync(user))
                    {

                        return new AuthResponseDto { MensajeError = "The account is blocked." };
                    }

                    return new AuthResponseDto { MensajeError = "Invalid authentication." };
                }


                var token = await _jwtHandler.CreateToken(user);

                await _userManager.ResetAccessFailedCountAsync(user);

                return new AuthResponseDto { AuthExitosa = true, Token = token };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RegisterResponseDto> Register(RegisterUserDto request)
        {
            try
            {
                var response = new RegisterResponseDto();

                var user = _mapper.Map<Users>(request);

                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    response.IsSuccess = false;
                    response.Errors = errors;
                    return response;
                }

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
