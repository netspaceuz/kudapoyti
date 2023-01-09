using AutoMapper;
using kudapoyti.Service.Dtos;
using Microsoft.Graph;

namespace kudapoyti.api.Configurations;
public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<PlaceCreateDto, Place>().ReverseMap();
        
    }
}