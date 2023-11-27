using AutoMapper;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using EasyStay.Models.Models;

namespace EasyStay.WebApi.Configurations
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Users, RegisterUserRequestDto>().ReverseMap();

            CreateMap<Hotel, HotelRequestDto>().ReverseMap();
            CreateMap<Hotel, HotelResponseDto>().ReverseMap();
            CreateMap<HotelRequestDto, HotelResponseDto>().ReverseMap();
            
            CreateMap<Room, RoomRequestDto>().ReverseMap();
            CreateMap<Room, RoomResponseDto>().ReverseMap();
            CreateMap<RoomRequestDto, RoomResponseDto>().ReverseMap();
        }
    }
}
