using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        [HttpGet("enable")]
        public async Task<IActionResult> GetHotels()
        {

            var result = await _hotelService.GetHotels();
            return Ok(result);
        }

        [HttpGet("disable")]
        public async Task<IActionResult> GetHotelDisable()
        {

            var result = await _hotelService.GetHotelDisable();
            return Ok(result);
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

            var result = await _hotelService.AddHotel(request);
            return Ok(result);
        }

        [HttpPatch("update-hotel-by/{hotelId}")]
        public async Task<IActionResult> UprdateHotel(Guid hotelId, HotelRequestDto request)
        {

            var result = await _hotelService.UpdadatedHotel(hotelId, request);
            return Ok(result);
        }

        [HttpDelete("delete-hotel-by/{hotelId}")]
        public async Task<IActionResult> DeleteHotel(Guid hotelId)
        {

            var result = await _hotelService.DeleteHotel(hotelId);
            return Ok(result);
        }
    }
}
