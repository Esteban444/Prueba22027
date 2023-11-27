using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;

namespace EasyStay.Contracts.Services
{
    public interface IHotelService
    {
        public Task<IEnumerable<HotelResponseDto>> GetHotels();
        public Task<IEnumerable<HotelResponseDto>> GetHotelDisable();
        public Task<HotelResponseDto> GetHotel(Guid id);
        public Task<HotelResponseDto> AddHotel(HotelRequestDto request);
        public Task<HotelResponseDto> UpdadatedHotel(Guid id, HotelRequestDto request);
        public Task<HotelResponseDto> DeleteHotel(Guid id);
    }
}
