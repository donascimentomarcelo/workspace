using AutoMapper;
using ProEvents.Application.Dtos;
using ProEvents.Domain;

namespace Event.API.Helper
{
    public class PartyProfile : Profile
    {
        public PartyProfile()
        {
            CreateMap<Party, PartyDto>().ReverseMap();
        }

    }
}
