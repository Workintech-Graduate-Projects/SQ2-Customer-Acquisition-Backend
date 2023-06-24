using CRM.Application.Interfaces.Repositories;
using CRM.Domain.Entities;
using CRM_Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DataAccess.Repositories
{
    public class SectorRepository : GenericRepository<Sector>, ISectorRepository
    {
        public SectorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
