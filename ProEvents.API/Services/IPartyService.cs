

using ProEvents.Application.Dtos;

namespace Event.API.Services
{
    public interface IPartyService
    {
        Task<PartyDto> Add(PartyDto party);
        Task<PartyDto> Update(int id, PartyDto party);
        Task<bool> Remove(int id);
        Task<PartyDto[]> GetAllPartiesByThemeAsync(string theme, bool includeSpeakers = false);
        Task<PartyDto[]> GetAllPartiesAsync(bool includeSpeakers = false);
        Task<PartyDto> GetPartyByIdAsync(int id, bool includeSpeakers = false);
    }
}
