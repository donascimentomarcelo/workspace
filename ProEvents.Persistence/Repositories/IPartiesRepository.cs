using ProEvents.Domain;

namespace ProEvents.Persistence.Repositories
{
    public interface IPartiesRepository
    {
        Task<Party[]> GetAllPartiesByThemeAsync(string theme, bool includeSpeakers);
        Task<Party[]> GetAllPartiesAsync(bool includeSpeakers);
        Task<Party> GetPartyByIdAsync(int id, bool includeSpeakers);
    }
}
