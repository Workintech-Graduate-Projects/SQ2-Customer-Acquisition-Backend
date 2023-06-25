using AutoMapper;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Repositories;
using CRM.Application.Interfaces.Services;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerDto> AddAsync(CustomerDto entity)
        {
            Customer customer = mapper.Map<CustomerDto, Customer>(entity);
            await customerRepository.AddAsync(customer);

            return entity;
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            var customers = await customerRepository.GetAll();
            List<CustomerDto> customerDtos = new();

            foreach (var customer in customers)
            {
                var customerDto = mapper.Map<Customer, CustomerDto>(customer);
                customerDtos.Add(customerDto);
            }

            return customerDtos;

        }

        public async Task<CustomerDto> Update(CustomerDto entity)
        {
            Customer customer = mapper.Map<CustomerDto, Customer>(entity);
            await customerRepository.Update(customer);

            return entity;
        }

    }
}
