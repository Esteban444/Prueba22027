using EasyStay.Contracts.Services;
using EasyStay.Models.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyStay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetResrvations()
        {

            var result = await _reservationService.GetReservations();
            return Ok(result);
        }

        [HttpGet("search-reservation-by/{reservationId}")]
        public async Task<IActionResult> GetReservation(Guid reservationId)
        {

            var result = await _reservationService.GetReservation(reservationId);
            return Ok(result);
        }

        [HttpGet("search-client-reservation-by/{clientId}")]
        public async Task<IActionResult> GetReservationByClient(Guid clientId)
        {

            var result = await _reservationService.GetReservationByClient(clientId);
            return Ok(result);
        }

        [HttpPost("add-reservation")]
        public async Task<IActionResult> AddReservation(List<ReservationRequestDto> request)
        {
            try
            {
                var result = await _reservationService.AddReservation(request);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("update-reservation-by/{reservationId}")]
        public async Task<IActionResult> UprdateReservation(Guid reservationId, ReservationRequestDto request)
        {
            try
            {
                var result = await _reservationService.UpdadateReservation(reservationId, request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete-reservation-by/{reservationId}")]
        public async Task<IActionResult> DeleteReservation(Guid reservationId)
        {
            try
            {
                var result = await _reservationService.DeleteReservation(reservationId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
