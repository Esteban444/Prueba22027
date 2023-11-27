using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
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
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegisterUserRequestDto request)
        {
            var result = await _accountService.Register(request);
            return Ok(result);
        }
    }
}
