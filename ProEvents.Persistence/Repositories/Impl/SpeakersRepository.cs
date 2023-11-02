using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;

namespace ProEvents.Persistence.Repositories.Impl
{
    public class SpeakersRepository : ISpeakersRepository
    {
        private readonly DataContext context;

        public SpeakersRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeParties)
        {
            IQueryable<Speaker> query = context.Speakers.Include(s => s.SocialNetworks);

            if (includeParties)
                query = query.Include(party => party.SpeakerParties)
                             .ThenInclude(speakerParty => speakerParty.Party);

            query = query
                .OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeParties)
        {
            IQueryable<Speaker> query = context.Speakers.Include(s => s.SocialNetworks);

            if (includeParties)
                query = query.Include(party => party.SpeakerParties)
                             .ThenInclude(speakerParty => speakerParty.Party);

            query = query
                .OrderBy(s => s.Id)
                .Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int id, bool includeParties)
        {
            IQueryable<Speaker> query = context.Speakers.Include(s => s.SocialNetworks);

            if (includeParties)
                query = query.Include(party => party.SpeakerParties)
                             .ThenInclude(speakerParty => speakerParty.Party);

            query = query.OrderBy(s => s.Id)
                .Where(s => s.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
