using EasyStay.Models.Dto.Filters;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;

namespace EasyStay.Contracts.Services
{
    public interface IRoomService
    {
        public Task<List<RoomResponseDto>> GetRooms(RoomFilter filter);
        public Task<IEnumerable<RoomResponseDto>> GetRoomsDisable();
        public Task<RoomResponseDto> GetRoom(Guid id);
        public Task<List<RoomResponseDto>> AddRoom(List<RoomRequestDto> request);
        public Task<RoomResponseDto> UpdadateRoom(Guid id, RoomRequestDto request);
        public Task<RoomResponseDto> DeleteRoom(Guid id);
    }
}
