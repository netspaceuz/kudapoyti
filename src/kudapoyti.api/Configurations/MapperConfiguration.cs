using AutoMapper;
using kudapoyti.Service.Dtos.Places;
using Microsoft.Graph;

namespace kudapoyti.api.Configurations;
public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<PlaceCreateDto, Place>().ReverseMap();
        
    }
}