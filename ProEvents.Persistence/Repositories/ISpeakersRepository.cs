using ProEvents.Domain;

namespace ProEvents.Persistence.Repositories
{
    internal interface ISpeakersRepository
    {
        Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeParties);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeParties);
        Task<Speaker> GetSpeakerByIdAsync(int id, bool includeParties);
    }
}
