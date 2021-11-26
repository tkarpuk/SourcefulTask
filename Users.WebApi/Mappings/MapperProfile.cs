using AutoMapper;
using Users.Application.Users.Commands;
using Users.Domain.Entities;
using Users.WebApi.DTO;

namespace Users.WebApi.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserInfo, UserDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Film, FilmDto>().ReverseMap();

            CreateMap<CreateUserCommand, UserDto>().ReverseMap();
            CreateMap<UpdateUserCommand, UserDto>().ReverseMap();
            //CreateMap<Film, FilmDto>().ReverseMap();
        }
    }
}
