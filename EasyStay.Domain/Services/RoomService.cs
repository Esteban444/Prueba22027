using AutoMapper;
using EasyStay.Contracts.Repositories;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using EasyStay.Models.Models;
using System.Data.Entity;
using System.Net;

namespace EasyStay.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepocitory;
        private readonly IHotelRepository _hotelRepocitory;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository roomRepository, IMapper mapper,IHotelRepository hotelRepository)
        {
            this._roomRepocitory = roomRepository;
            this._mapper = mapper;
            this._hotelRepocitory= hotelRepository;
        }
        public async Task<List<RoomResponseDto>> AddRoom(List<RoomRequestDto> request)
        {
            try
            {
                var hotelId = request.Select(x => x.HotelId).FirstOrDefault();
                var result = await _hotelRepocitory.FindByAsync(x => x.Id == hotelId);
                var hotel = result.FirstOrDefault();
                if (hotel!.Available)
                {
                    var newHotel = _mapper.Map<List<Room>>(request);
                    await _roomRepocitory.AddRange(newHotel);
                    var response = _mapper.Map<List<RoomResponseDto>>(newHotel);
                    return response;

                }
                else
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The hotel is not available for room additions." });
                }
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomResponseDto> GetRoom(Guid id)
        {
            try
            {
                var response = await _roomRepocitory.FindByAsNoTracking(x => x.Available && x.Id == id).FirstOrDefaultAsync();
                //var response = result.FirstOrDefault();
                if (response != null)
                {
                    return _mapper.Map<RoomResponseDto>(response);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The room does not exist or is not available." });
            }
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRooms()
        {
            try
            {
                var rooms = await _roomRepocitory.FindByAsNoTracking(x => x.Available).ToListAsync();
                //await Task.FromResult(rooms);
                return _mapper.Map<IEnumerable<RoomResponseDto>>(rooms);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRoomsDisable()
        {
            try
            {
                var rooms = await _roomRepocitory.FindByAsNoTracking(x => x.Available == false).ToListAsync();
                //await Task.FromResult(rooms);
                return _mapper.Map<IEnumerable<RoomResponseDto>>(rooms);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomResponseDto> UpdadateRoom(Guid id, RoomRequestDto request)
        {
            try
            {
                var preResult = await _roomRepocitory.FindByAsync(x => x.Id == id);
                var result = preResult.FirstOrDefault();
                if (result != null)
                {
                    var properties = new UpdatedMapperProperties<Room, RoomRequestDto>();
                    var resultToUpdate = await properties.MapperUpdate(result!, request);

                    await _roomRepocitory.Update(resultToUpdate);
                    var response = _mapper.Map<RoomResponseDto>(resultToUpdate);
                    return response;
                }
                else
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "The room you wish to update does not exist in the database." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomResponseDto> DeleteRoom(Guid id)
        {
            try
            {
                var result = await _roomRepocitory.FindByAsync(x => x.Available && x.Id == id);
                var response = result.FirstOrDefault();
                if (response != null)
                {
                    await _roomRepocitory.Delete(response);
                }
                return _mapper.Map<RoomResponseDto>(response);
            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The room cannot be deleted from the database." });

            }
        }
    }
}
