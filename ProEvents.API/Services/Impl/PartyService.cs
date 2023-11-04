using ProEvents.Domain;
using ProEvents.Persistence.Repositories;

namespace Event.API.Services.Impl
{
    public class PartyService : IPartyService
    {
        private readonly IPartiesRepository partiesRepository;
        private readonly IGenericRepository genericRepository;

        public PartyService(IPartiesRepository partiesRepository, IGenericRepository genericRepository)
        {
            this.partiesRepository = partiesRepository;
            this.genericRepository = genericRepository;
        }
        public async Task<Party> Add(Party party)
        {
            try
            {
                genericRepository.Add(party);
                if (await genericRepository.SaveChangesAsync())
                    return await partiesRepository.GetPartyByIdAsync(party.Id, false);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var party = await partiesRepository.GetPartyByIdAsync(id, false);
                if (party == null) throw new Exception("Party not found!");

                genericRepository.Delete(party);
                return await genericRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Party> Update(int id, Party model)
        {
            try
            {
                var party = partiesRepository.GetPartyByIdAsync(id, false);
                if (party == null) return null;

                model.Id = id;
                genericRepository.Update(model);
                if (await genericRepository.SaveChangesAsync())
                    return await partiesRepository.GetPartyByIdAsync(party.Id, false);
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Party[]> GetAllPartiesAsync(bool includeSpeakers = false)
        {
            try
            {
                return await partiesRepository.GetAllPartiesAsync(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Party[]> GetAllPartiesByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                return await partiesRepository.GetAllPartiesByThemeAsync(theme, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Party> GetPartyByIdAsync(int id, bool includeSpeakers = false)
        {
            try
            {
                return await partiesRepository.GetPartyByIdAsync(id, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
