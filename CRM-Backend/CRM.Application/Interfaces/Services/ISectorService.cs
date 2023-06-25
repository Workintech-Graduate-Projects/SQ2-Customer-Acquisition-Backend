using CRM.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Services
{
    public interface ISectorService
    {
        Task<List<SectorDto>> GetAll();
        Task<SectorDto> GetById(int id);
        Task<SectorDto> AddAsync(SectorDto entity);
        Task<SectorDto> Update(SectorDto entity);
    }
}
