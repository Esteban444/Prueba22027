using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientService _clietservise;
        public ClientsController(IClientService clientService)
        {
           this._clietservise = clientService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetClients()
        {

            var result = await _clietservise.GetClients();
            return Ok(result);
        }

        [HttpGet("search-client-by/{clientId}")]
        public async Task<IActionResult> GetClient(Guid clientId)
        {

            var result = await _clietservise.GetClient(clientId);
            return Ok(result);
        }

        [HttpPost("add-client")]
        public async Task<IActionResult> AddClient(ClientRequestDto request)
        {
            try
            {
                var result = await _clietservise.AddClient(request);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("update-client-by/{clientId}")]
        public async Task<IActionResult> UprdateClient(Guid clientId, ClientRequestDto request)
        {
            try
            {
                var result = await _clietservise.UpdadateClient(clientId, request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete-client-by/{clientId}")]
        public async Task<IActionResult> DeleteClient(Guid clientId) 
        {
            try
            {
                var result = await _clietservise.DeleteClient(clientId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
