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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository positionRepository;
        private readonly IMapper mapper;
        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            this.positionRepository = positionRepository;
            this.mapper = mapper;
        }

        public async Task<PositionDto> AddAsync(PositionDto entity)
        {
            Position position = mapper.Map<PositionDto, Position>(entity);
            await positionRepository.AddAsync(position);

            return entity;
        }

        public async Task<List<PositionDto>> GetAll()
        {
            var positions = await positionRepository.GetAll();
            List<PositionDto> positionDtos = new();

            foreach (var position in positions)
            {
                var positionDto = mapper.Map<Position, PositionDto>(position);
                positionDtos.Add(positionDto);
            }

            return positionDtos;
        }

        public async Task<PositionDto> GetById(int id)
        {
            var searchedPosition = await positionRepository.GetById(id);

            var positionDto = mapper.Map<Position, PositionDto>(searchedPosition);

            return positionDto;
        }

        public async Task<PositionDto> Update(PositionDto entity)
        {
            Position position = mapper.Map<PositionDto, Position>(entity);
            await positionRepository.Update(position);

            return entity;
            
        }
    }
}
