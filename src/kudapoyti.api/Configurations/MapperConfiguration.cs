using AutoMapper;
using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Domain.Entities.Places;
using kudapoyti.Service.Dtos;
using kudapoyti.Service.ViewModels;

namespace kudapoyti.api.Configurations;
public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        //CreateMap<PlaceCreateDto, Place>().ReverseMap();
        //CreateMap<PlaceUpdateDto, Place>().ReverseMap();
        CreateMap<PlaceViewModel, Place >().ReverseMap();
        CreateMap<AdminCreateDto,Admin1>().ReverseMap(); 
        CreateMap<AdminViewModel, Admin1>().ReverseMap();
    }
}