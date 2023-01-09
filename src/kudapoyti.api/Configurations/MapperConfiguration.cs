using AutoMapper;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.Dtos.Accounts;
using kudapoyti.Service.ViewModels;
using Microsoft.Graph;

namespace kudapoyti.api.Configurations;
public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<PlaceCreateDto, Place>().ReverseMap();
        CreateMap<AdminCreateDto,Admin>().ReverseMap(); 
        CreateMap<AdminViewModel, Admin>().ReverseMap();
    }
}