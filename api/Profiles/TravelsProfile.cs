using AutoMapper;
using MyTravels.API.Models;

namespace MyTravels.API.Profiles
{
    /// <summary>
    /// Automappers configuration file for Travels
    /// </summary>
    public class TravelsProfile : Profile
    {
        /// <summary>
        /// All mapping constructs have to be initiated in the constructor
        /// </summary>
        public TravelsProfile() 
        { 
            CreateMap<Entities.Travel, TravelDto>();
            CreateMap<Entities.Travel, TravelWithoutSubTravelsDto>();
            CreateMap<TravelForCreationDto, Entities.Travel>();
        }
    }
}
