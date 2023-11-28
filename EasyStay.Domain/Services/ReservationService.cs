using AutoMapper;
using EasyStay.Contracts.Repositories;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using EasyStay.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EasyStay.Domain.Services
{
    public class ReservationService: IReservationService
    {
        public readonly IReservationRepository _reservationRepository;
        public readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository,IMapper mapper, IClientRepository clientRepository)
        {
            this._reservationRepository = reservationRepository;
            this._mapper = mapper;
            this._clientRepository = clientRepository;

        }

        public async Task<List<ReservationResponseDto>> AddReservation(List<ReservationRequestDto> request)
        {
            try
            {
                var result = _mapper.Map<List<Reservation>>(request);
                await _reservationRepository.AddRange(result);
                var response = _mapper.Map<List<ReservationResponseDto>>(result);
                return response;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReservationResponseDto> DeleteReservation(Guid id)
        {
            try
            {
                var response = await _reservationRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
                if (response != null)
                {
                    await _reservationRepository.Delete(response);
                }
                return _mapper.Map<ReservationResponseDto>(response);
            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The Reservation cannot be deleted from the database." });

            }
        }

        public async Task<ReservationResponseDto> GetReservation(Guid id)
        {
            try
            {
                var response = await _reservationRepository.FindByAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
                if (response != null)
                {
                    return _mapper.Map<ReservationResponseDto>(response);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The reservation does not exist or is not available." });
            }
        }

        public async Task<List<ReservationResponseDto>> GetReservationByClient(Guid id)
        {
            try
            {
                var client = await _clientRepository.FindByAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
                if (client == null) throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The client does not exist or is not available." });

                var result = await _reservationRepository.FindByAsNoTracking(x => x.ClientId == id).Include(x => x.Client).ToListAsync();
                if (result != null)
                {
                    return _mapper.Map<List<ReservationResponseDto>>(result);
                }
                else
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The client has no reservations." });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ReservationResponseDto>> GetReservations()
        {
            try
            {
                var result = await _reservationRepository.GetAll().ToListAsync();
                var response = _mapper.Map<IEnumerable<ReservationResponseDto>>(result);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReservationResponseDto> UpdadateReservation(Guid id, ReservationRequestDto request)
        {
            try
            {
                var result = await _reservationRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    var properties = new UpdatedMapperProperties<Reservation, ReservationRequestDto>();
                    var resultToUpdate = await properties.MapperUpdate(result!, request);

                    await _reservationRepository.Update(resultToUpdate);
                    var response = _mapper.Map<ReservationResponseDto>(resultToUpdate);
                    return response;
                }
                else
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "The reservation you wish to update does not exist in the database." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
