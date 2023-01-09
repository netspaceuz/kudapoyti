using AutoMapper;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.Accounts;
using Microsoft.Graph;

namespace kudapoyti.api.Configurations;
public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<PlaceCreateDto, Place>().ReverseMap();
        CreateMap<AdminAccountRegisterDto,Admin>().ReverseMap();    
    }
}