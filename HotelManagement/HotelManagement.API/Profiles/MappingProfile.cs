using AutoMapper;
using HotelManagement.Core.Entities;

namespace HotelManagement.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hotel, HotelDTO>();
        CreateMap<HotelDTO, Hotel>();
    }
}