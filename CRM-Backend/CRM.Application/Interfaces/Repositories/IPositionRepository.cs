using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Repositories
{
    public interface IPositionRepository :IGenericRepository<Position>
    {
        Task<Dictionary<string, int>> GetPositionNamesAndIds();
    }
}
