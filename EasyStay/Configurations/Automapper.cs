using AutoMapper;
using EasyStay.Models.Dto;
using EasyStay.Models.Models;

namespace EasyStay.WebApi.Configurations
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Users, RegisterUserDto>().ReverseMap();

            
        }
    }
}
