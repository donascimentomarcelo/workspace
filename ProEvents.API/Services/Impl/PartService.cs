using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProEvents.Application.Dtos;
using ProEvents.Domain;
using ProEvents.Persistence.Repositories;

namespace Event.API.Services.Impl
{
    public class PartService : IPartService
    {
        private readonly IPartsRepository partsRepository;
        private readonly IGenericRepository genericRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;


        public PartService(
            IPartsRepository partsRepository,
            IGenericRepository genericRepository,
            IMapper mapper,
            IWebHostEnvironment environment)
        {
            this.partsRepository = partsRepository;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
            this.environment = environment;

        }

        public async Task AddPart(int id, PartDto dto)
        {
            try
            {
                var part = mapper.Map<Part>(dto);
                part.Id = id;

                genericRepository.Add<Part>(part);
                await genericRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartDto[]> Update(int id, PartDto[] dtos)
        {
            try
            {
                var parts = await partsRepository.GetPartsByPartyId(id);
                if (parts == null) return null;

                foreach (var dto in dtos)
                {
                    if (dto.Id == 0)
                    {
                        await AddPart(id, dto);
                    }
                    else
                    {
                        var part = parts.FirstOrDefault(part => part.Id == dto.Id);
                        dto.PartyId = id;
                        mapper.Map(dto, part);
                        await genericRepository.SaveChangesAsync();
                    }

                }

                var resp = await partsRepository.GetPartsByPartyId(id);
                return mapper.Map<PartDto[]>(resp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> Remove(int partyId, int id)
        {
            try
            {
                var part = await partsRepository.GetPartByIdAsync(partyId, id);
                if (part == null) throw new Exception("Part not found!");

                genericRepository.Delete(part);
                return await genericRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartDto[]> GetPartsByPartyId(int partyId)
        {
            try
            {
                var parts = await partsRepository.GetPartsByPartyId(partyId);
                var dto = mapper.Map<PartDto[]>(parts);
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartDto> GetPartByIdAsync(int partyId, int id)
        {
            try
            {
                var party = await partsRepository.GetPartByIdAsync(partyId, id);
                var dto = mapper.Map<PartDto>(party);
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
