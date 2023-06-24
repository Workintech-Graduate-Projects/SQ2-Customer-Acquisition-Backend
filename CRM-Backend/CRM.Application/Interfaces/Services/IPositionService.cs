using CRM.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Services
{
    public interface IPositionService
    {
        Task<List<PositionDto>> GetAll();
        Task<PositionDto> GetById(int id);
        Task<PositionDto> AddAsync(PositionDto entity);
        Task<PositionDto> Update(PositionDto entity);
    }
}
