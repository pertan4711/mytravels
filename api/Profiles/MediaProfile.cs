using AutoMapper;
using MyTravels.API.Models;

namespace MyTravels.API.Profiles
{
    public class MediaProfile : Profile
    {
        public MediaProfile() 
        { 
            CreateMap<Entities.Media, MediaDto>();
            CreateMap<Entities.Media, MediaForUpdateDto>();
            CreateMap<MediaForCreationDto, Entities.Media>();
            CreateMap<MediaForUpdateDto, Entities.Media>();
        }
    }
}
