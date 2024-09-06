using AutoMapper;
using MyTravels.API.Models;

namespace MyTravels.API.Profiles
{
    /// <summary>
    /// Automappers configuration file for Media
    /// </summary>
    public class MediaProfile : Profile
    {
        /// <summary>
        /// All mapping constructs have to be initiated in the constructor
        /// </summary>
        public MediaProfile() 
        { 
            CreateMap<Entities.Media, MediaDto>();
            CreateMap<Entities.Media, MediaForUpdateDto>();
            CreateMap<MediaForCreationDto, Entities.Media>();
            CreateMap<MediaForUpdateDto, Entities.Media>();
        }
    }
}
