using CRM.Application.Interfaces.Repositories;
using CRM.Domain.Entities;
using CRM_Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DataAccess.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PositionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, int>> GetPositionNamesAndIds()
        {
            Dictionary<string, int> positonNamesAndIds = new();

            var allPositions = await _dbContext.Positions.ToListAsync();

            for (int i = 0; i < allPositions.Count; i++)
            {
                positonNamesAndIds.Add(allPositions[i].Name, allPositions[i].Id);
            }

            return positonNamesAndIds;
        }
    }
}
