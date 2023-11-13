

using ProEvents.Application.Dtos;

namespace Event.API.Services
{
    public interface IPartService
    {
        Task<PartDto[]> Update(int id, PartDto[] parts);
        Task AddPart(int id, PartDto dto);
        Task<bool> Remove(int partyId, int id);
        Task<PartDto[]> GetPartsByPartyId(int partyId);
        Task<PartDto> GetPartByIdAsync(int partyId, int id);
    }
}
