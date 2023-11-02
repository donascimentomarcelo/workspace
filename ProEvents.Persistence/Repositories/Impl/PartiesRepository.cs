using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;

namespace ProEvents.Persistence.Repositories.Impl
{
    public class PartiesRepository : IPartiesRepository
    {
        private readonly DataContext context;

        public PartiesRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<Party[]> GetAllPartiesAsync(bool includeSpeakers)
        {
            IQueryable<Party> query = context.Parties.Include(party => party.Parts)
                .Include(party => party.SocialNetwork);

            if (includeSpeakers)
                query = query.Include(party => party.SpeakerParties)
                             .ThenInclude(speakerParty => speakerParty.Speaker);

            query = query
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Party[]> GetAllPartiesByThemeAsync(string theme, bool includeSpeakers)
        {
            IQueryable<Party> query = context.Parties.Include(party => party.Parts)
                .Include(party => party.SocialNetwork);

            if (includeSpeakers)
                query = query.Include(party => party.SpeakerParties)
                             .ThenInclude(speakerParty => speakerParty.Speaker);

            query = query
                .OrderBy(e => e.Id)
                .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Party> GetPartyByIdAsync(int id, bool includeSpeakers)
        {
            IQueryable<Party> query = context.Parties.Include(party => party.Parts)
               .Include(party => party.SocialNetwork);

            if (includeSpeakers)
                query = query.Include(party => party.SpeakerParties)
                             .ThenInclude(speakerParty => speakerParty.Speaker);

            query = query
                .OrderBy(e => e.Id)
                .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
