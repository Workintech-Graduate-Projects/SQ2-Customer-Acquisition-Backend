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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> UpdateCustomerDataFromTypeform(List<Customer> entity)
        {
            await _dbContext.Set<Customer>().AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<Customer>().ToListAsync();
        }
    }
}
