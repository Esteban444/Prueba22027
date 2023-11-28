using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Filters;
using EasyStay.Models.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        [HttpGet("enable")]
        public async Task<IActionResult> GetRooms([FromQuery] RoomFilter filter)
        {

            var result = await _roomService.GetRooms(filter);
            return Ok(result);
        }

        [HttpGet("disable")]
        public async Task<IActionResult> GetRoomsDisable()
        {
            try
            {
                var result = await _roomService.GetRoomsDisable();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("search-room-enable-by/{roomId}")]
        public async Task<IActionResult> GetRoom(Guid roomId)
        {

            var result = await _roomService.GetRoom(roomId);
            return Ok(result);
        }

        [HttpPost("add-room")]
        public async Task<IActionResult> AddRoom(List<RoomRequestDto> request)
        {
            try
            {
                var result = await _roomService.AddRoom(request);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("update-room-by/{roomId}")]
        public async Task<IActionResult> UprdateRoom(Guid roomId, RoomRequestDto request)
        {
            try
            {
                var result = await _roomService.UpdadateRoom(roomId, request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete-room-by/{roomId}")]
        public async Task<IActionResult> DeleteRoom(Guid roomId)
        {
            try
            {
                var result = await _roomService.DeleteRoom(roomId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
