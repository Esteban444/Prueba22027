using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        [HttpGet("enable")]
        public async Task<IActionResult> GetRooms()
        {

            var result = await _roomService.GetRooms();
            return Ok(result);
        }

        [HttpGet("disable")]
        public async Task<IActionResult> GetRoomsDisable()
        {

            var result = await _roomService.GetRoomsDisable();
            return Ok(result);
        }

        [HttpGet("search-room-by/{roomId}")]
        public async Task<IActionResult> GetRoom(Guid roomId)
        {

            var result = await _roomService.GetRoom(roomId);
            return Ok(result);
        }

        [HttpPost("add-room")]
        public async Task<IActionResult> AddRoom(List<RoomRequestDto> request)
        {

            var result = await _roomService.AddRoom(request);
            return Ok(result);
        }

        [HttpPatch("update-room-by/{roomId}")]
        public async Task<IActionResult> UprdateRoom(Guid roomId, RoomRequestDto request)
        {

            var result = await _roomService.UpdadateRoom(roomId, request);
            return Ok(result);
        }

        [HttpDelete("delete-room-by/{roomId}")]
        public async Task<IActionResult> DeleteRoom(Guid roomId)
        {

            var result = await _roomService.DeleteRoom(roomId);
            return Ok(result);
        }
    }
}
