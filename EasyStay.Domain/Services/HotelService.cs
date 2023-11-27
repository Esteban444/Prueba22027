using AutoMapper;
using EasyStay.Contracts.Repositories;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using EasyStay.Models.Models;
using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace EasyStay.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            this._hotelRepository = hotelRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<HotelResponseDto>> GetHotels()
        {
            try
            {
                var result = await _hotelRepository.FindByAsNoTracking(x => x.Available).ToArrayAsync();
                //await Task.FromResult(result);
                return _mapper.Map<IEnumerable<HotelResponseDto>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HotelResponseDto> GetHotel(Guid id)
        {
            try
            {
                var response = await _hotelRepository.FindByAsNoTracking(x => x.Available && x.Id == id).FirstOrDefaultAsync();
                //var response = result.FirstOrDefault();
                if (response != null)
                {
                    return _mapper.Map<HotelResponseDto>(response);
                }
                else
                {
                    throw new Exception();
                }
               
            }
            catch (Exception )
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The hotel does not exist or is not available." });
            }
        }

        public async Task<HotelResponseDto> AddHotel(HotelRequestDto request)
        {
            try
            {
                var newHotel = _mapper.Map<Hotel>(request);
                await _hotelRepository.Add(newHotel);
                var response = _mapper.Map<HotelResponseDto>(newHotel);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HotelResponseDto> UpdadatedHotel(Guid id, HotelRequestDto request)
        {
            try
            {
                var preResult = await _hotelRepository.FindByAsync(x => x.Id == id);
                var result = preResult.FirstOrDefault();
                if (result != null)
                {
                    var properties = new UpdatedMapperProperties<Hotel, HotelRequestDto>();
                    var resultToUpdate = await properties.MapperUpdate(result!, request);

                    await _hotelRepository.Update(resultToUpdate);
                    var response = _mapper.Map<HotelResponseDto>(resultToUpdate);
                    return response;
                }
                else
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "The hotel you wish to update does not exist in the database." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HotelResponseDto> DeleteHotel(Guid id)
        {
            try
            {
                var result = await _hotelRepository.FindByAsync(x => x.Id == id);
                var hotel = result.FirstOrDefault();
                if (hotel != null)
                {
                   await _hotelRepository.Delete(hotel);
                }
                return _mapper.Map<HotelResponseDto>(hotel);
            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The hotel cannot be deleted from the database." });

            }
        }

        public async Task<IEnumerable<HotelResponseDto>> GetHotelDisable()
        {
            try
            {
                var result = await _hotelRepository.FindByAsNoTracking(x => x.Available == false).FirstOrDefaultAsync();
                //await Task.FromResult(result);
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<HotelResponseDto>>(result);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "There are no hotels for enable." });
            }
        }
    }
}
