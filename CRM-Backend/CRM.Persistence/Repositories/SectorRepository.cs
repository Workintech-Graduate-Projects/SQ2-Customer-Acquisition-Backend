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
    public class SectorRepository : GenericRepository<Sector>, ISectorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SectorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, int>> GetSectorNamesAndIds()
        {
            Dictionary<string, int> sectorNamesAndIds = new();

            var allSectors = await _dbContext.Sectors.ToListAsync();

            for (int i = 0; i < allSectors.Count; i++)
            {
                sectorNamesAndIds.Add(allSectors[i].Name, allSectors[i].Id);
            }

            return sectorNamesAndIds;
        }
    }
}
