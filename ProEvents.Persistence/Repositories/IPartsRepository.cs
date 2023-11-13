using ProEvents.Domain;

namespace ProEvents.Persistence.Repositories
{
    public interface IPartsRepository
    {
        Task<Part[]> GetPartsByPartyId(int partyId);
        Task<Part> GetPartByIdAsync(int partyId, int id);
    }
}
