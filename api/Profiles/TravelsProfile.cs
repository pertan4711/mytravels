using AutoMapper;
using MyTravels.API.Models;

namespace MyTravels.API.Profiles
{
    public class TravelsProfile : Profile
    {
        public TravelsProfile() 
        { 
            CreateMap<Entities.Travel, TravelDto>();
            CreateMap<Entities.Travel, TravelWithoutSubTravelsDto>();
            CreateMap<TravelForCreationDto, Entities.Travel>();
        }
    }
}
