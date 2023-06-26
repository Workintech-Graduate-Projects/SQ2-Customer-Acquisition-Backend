using CRM.Application.Dtos;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAll();
        Task<CustomerDto> GetById(int id);
        Task<CustomerDto> AddAsync(CustomerDto entity);
        Task<CustomerDto> Update(CustomerDto entity);
        Task<List<CustomerDto>> UpdateCustomerDataFromTypeform();
    }
}
