using AutoMapper;
using ProEvents.Application.Dtos;
using ProEvents.Domain;
using ProEvents.Persistence.Repositories;

namespace Event.API.Services.Impl
{
    public class PartyService : IPartyService
    {
        private readonly IPartiesRepository partiesRepository;
        private readonly IGenericRepository genericRepository;
        private readonly IMapper mapper;

        public PartyService(
            IPartiesRepository partiesRepository,
            IGenericRepository genericRepository,
            IMapper mapper)
        {
            this.partiesRepository = partiesRepository;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }
        public async Task<PartyDto> Add(PartyDto dto)
        {
            try
            {
                var party = mapper.Map<Party>(dto);
                genericRepository.Add(party);

                if (await genericRepository.SaveChangesAsync())
                    return mapper.Map<PartyDto>(
                        await partiesRepository.GetPartyByIdAsync(party.Id, false));
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

        public async Task<PartyDto> Update(int id, PartyDto dto)
        {
            try
            {
                var party = partiesRepository.GetPartyByIdAsync(id, false);
                if (party == null) return null;

                var model = mapper.Map<Party>(dto);
                model.Id = id;
                genericRepository.Update(model);
                if (await genericRepository.SaveChangesAsync())
                    return mapper.Map<PartyDto>(
                         await partiesRepository.GetPartyByIdAsync(party.Id, false));
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartyDto[]> GetAllPartiesAsync(bool includeSpeakers = false)
        {
            try
            {
                var parties = await partiesRepository.GetAllPartiesAsync(false);
                var partiesDto = mapper.Map<PartyDto[]>(parties);
                return partiesDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartyDto[]> GetAllPartiesByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var parties = await partiesRepository.GetAllPartiesByThemeAsync(theme, false);
                var partiesDto = mapper.Map<PartyDto[]>(parties);
                return partiesDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartyDto> GetPartyByIdAsync(int id, bool includeSpeakers = false)
        {
            try
            {
                var party = await partiesRepository.GetPartyByIdAsync(id, false);
                var dto = mapper.Map<PartyDto>(party);
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
