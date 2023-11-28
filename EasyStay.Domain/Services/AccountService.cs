using AutoMapper;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using EasyStay.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyStay.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly TokenHandler _jwtHandler;
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<Users> userManager, IMapper mapper, TokenHandler jwtHandler)
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

        public async Task<RegisterResponseDto> Register(RegisterUserRequestDto request)
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

                // Assign roles to the user
                var rolesToAssign = new List<string> { request.Role! };
                await AssignRoles(user.Id, rolesToAssign);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AssignRoles(string userId, IEnumerable<string> roles)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return false; 
                }

                // Obtén los roles actuales del usuario
                var currentRoles = await _userManager.GetRolesAsync(user);

                // Roles a agregar (nuevos roles que no están actualmente asignados)
                var rolesToAdd = roles.Except(currentRoles);

                // Roles a quitar (roles actuales que no se incluyen en la nueva lista de roles)
                var rolesToRemove = currentRoles.Except(roles);

                // Agrega los nuevos roles
                await _userManager.AddToRolesAsync(user, rolesToAdd);

                // Quita los roles no deseados
                await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

                return true; // Asignación de roles exitosa
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
