using AutoMapper;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Repositories;
using CRM.Application.Interfaces.Services;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository sectorRepository;
        private readonly IMapper mapper;
        public SectorService(ISectorRepository sectorRepository, IMapper mapper)
        {
            this.sectorRepository = sectorRepository;
            this.mapper = mapper;
        }
        public async Task<SectorDto> AddAsync(SectorDto entity)
        {
            Sector sector = mapper.Map<SectorDto, Sector>(entity);
            await sectorRepository.AddAsync(sector);

            return entity;
        }

        public async Task<List<SectorDto>> GetAll()
        {
            var sectors = await sectorRepository.GetAll();
            List<SectorDto> sectorDtos = new();

            foreach (var sector in sectors)
            {
                var sectorDto = mapper.Map<Sector, SectorDto>(sector);
                sectorDtos.Add(sectorDto);
            }
            return sectorDtos;
        }

        public async Task<SectorDto> GetById(int id)
        {
            var searchedSector = await sectorRepository.GetById(id);
            var sectorDto = mapper.Map<Sector, SectorDto>(searchedSector);

            return sectorDto;
        }

        public async Task<SectorDto> Update(SectorDto entity)
        {
            Sector sector = mapper.Map<SectorDto, Sector>(entity);
            await sectorRepository.Update(sector);

            return entity;
        }
    }
}
