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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            var user = await dbContext.Set<User>().FirstOrDefaultAsync(r=>r.Username == username && r.PasswordHash == password);

            return user;

        }
    }
}
