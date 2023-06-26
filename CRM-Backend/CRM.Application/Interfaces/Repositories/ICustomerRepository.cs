using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> AddRangeAsync(List<Customer> entity);

        Task<List<string>> GetAllLandingIds();
    }
}
