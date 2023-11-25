using EasyStay.Contracts.Services;
using EasyStay.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> InicioSeccion([FromBody] LoginRequestDto request)
        {
           
            var result = await _accountService.Login(request);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegisterUserDto request)
        {
            var result = await _accountService.Register(request);
            return Ok(result);
        }
    }
}
