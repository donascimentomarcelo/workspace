using ProEvents.Domain;

namespace Event.API.Services
{
    public interface IPartyService
    {
        Task<Party> Add(Party party);
        Task<Party> Update(int id, Party party);
        Task<bool> Remove(int id);
        Task<Party[]> GetAllPartiesByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Party[]> GetAllPartiesAsync(bool includeSpeakers = false);
        Task<Party> GetPartyByIdAsync(int id, bool includeSpeakers = false);
    }
}
