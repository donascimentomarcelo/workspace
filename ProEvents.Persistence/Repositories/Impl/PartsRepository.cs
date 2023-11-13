using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;

namespace ProEvents.Persistence.Repositories.Impl
{
    public class PartsRepository : IPartsRepository
    {
        private readonly DataContext context;

        public PartsRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Part> GetPartByIdAsync(int partyId, int id)
        {
            IQueryable<Part> query = context.Parts;
            query = query.AsNoTracking()
                         .Where(part => part.PartyId == partyId && part.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Part[]> GetPartsByPartyId(int partyId)
        {
            IQueryable<Part> query = context.Parts;
            query = query.AsNoTracking()
                         .Where(part => part.PartyId == partyId);
            return await query.ToArrayAsync();
        }
    }
}
