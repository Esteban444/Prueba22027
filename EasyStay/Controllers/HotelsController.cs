using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Users> _userManager;
        public HotelsController(IHotelService hotelService, IHttpContextAccessor httpContextAccessor, UserManager<Users> userManager)
        {
            this._hotelService = hotelService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        [HttpGet("enable")]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
               var result = await _hotelService.GetHotels();
               return Ok(result);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("disable")]
        public async Task<IActionResult> GetHotelDisable()
        {
            try
            {
                var result = await _hotelService.GetHotelDisable();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("search-hotel-available-by/{hotelId}")]
        public async Task<IActionResult> GetHotel(Guid hotelId)
        {

            var result = await _hotelService.GetHotel(hotelId);
            return Ok(result);
        }

        [HttpPost("add-hotel")]
        public async Task<IActionResult> AddHotel(HotelRequestDto request)
        {
            try
            {
                var result = await _hotelService.AddHotel(request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpPatch("update-hotel-by/{hotelId}")]
        public async Task<IActionResult> UprdateHotel(Guid hotelId, HotelRequestDto request)
        {
            try
            {
                var result = await _hotelService.UpdadatedHotel(hotelId, request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete-hotel-by/{hotelId}")]
        public async Task<IActionResult> DeleteHotel(Guid hotelId)
        {
            try
            {
                var result = await _hotelService.DeleteHotel(hotelId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
