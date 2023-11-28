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
                var result = await _hotelRepository.FindByAsNoTracking(x => x.Available).ToListAsync();
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
                var result = await _hotelRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
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
                var hotel = await _hotelRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
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
                var result = await _hotelRepository.FindByAsNoTracking(x => x.Available == false).ToListAsync();
                
                return _mapper.Map<IEnumerable<HotelResponseDto>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
