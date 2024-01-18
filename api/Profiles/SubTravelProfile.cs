using AutoMapper;

namespace MyTravels.API.Profiles
{
    public class SubTravelProfile : Profile
    {
        public SubTravelProfile()
        {
            CreateMap<Entities.SubTravel, Models.SubTravelDto>();
        }
    }
}
