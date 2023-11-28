using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;

namespace EasyStay.Contracts.Services
{
    public interface IReservationService
    {
        public Task<IEnumerable<ReservationResponseDto>> GetReservations();
        public Task<ReservationResponseDto> GetReservation(Guid id);
        public Task<List<ReservationResponseDto>> GetReservationByClient(Guid id);
        public Task<List<ReservationResponseDto>> AddReservation(List<ReservationRequestDto> request);
        public Task<ReservationResponseDto> UpdadateReservation(Guid id, ReservationRequestDto request);
        public Task<ReservationResponseDto> DeleteReservation(Guid id);
    }
}
