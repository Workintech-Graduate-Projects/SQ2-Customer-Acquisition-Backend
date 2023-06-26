using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Repositories;
using CRM.Application.Interfaces.Services;
using CRM.Domain.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CRM.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ISectorRepository sectorRepository;
        private readonly IPositionRepository positionRepository;
        private readonly IMapper mapper;
        public CustomerService(ICustomerRepository customerRepository, ISectorRepository sectorRepository, IPositionRepository positionRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.sectorRepository = sectorRepository;
            this.positionRepository = positionRepository;
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
        public async Task<CustomerDto> GetById(int id)
        {
            var searchedCustomer = await customerRepository.GetById(id);
            var sectorDto = mapper.Map<Customer, CustomerDto>(searchedCustomer);

            return sectorDto;
        }

        public async Task<CustomerDto> Update(CustomerDto entity)
        {
            Customer customer = mapper.Map<CustomerDto, Customer>(entity);
            await customerRepository.Update(customer);

            return entity;
        }

        public async Task<List<CustomerDto>> UpdateCustomerDataFromTypeform()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.typeform.com/forms/htBMgwwF/responses");
            request.Headers.Add("Authorization", "Bearer tfp_GBXtzBzbQCR6jehN7QxEEnTcBcSPL6UaxECRmwUcUrVq_3mJrwXQcHAPMcv");
            request.Method = "GET";

            List<Customer> customers = new();
            List<CustomerDto> customerDtos = new();
            Dictionary<string, int> sectors = await sectorRepository.GetSectorNamesAndIds();
            Dictionary<string, int> positions = await positionRepository.GetPositionNamesAndIds();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Process the response
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream);
                    string responseText = reader.ReadToEnd();

                    //Deserialize the responseText to a JSON array
                    JObject jo = JObject.Parse(responseText);
                    JArray items = jo["items"].Value<JArray>();
                    foreach (var it in items)
                    {
                        JObject item = it.Value<JObject>();
                        JArray answers = item["answers"].Value<JArray>();

                        CustomerDto dto = new();
                        dto.FirstName = (string?)answers[0]["text"];
                        dto.LastName = (string?)answers[1]["text"];
                        if (sectors.ContainsKey((string?)answers[2]["text"]))
                        {
                            dto.SectorId = sectors[(string?)answers[2]["text"]];
                        }
                        if (positions.ContainsKey((string?)answers[3]["text"]))
                        {
                            dto.PositionId = positions[(string?)answers[3]["text"]];
                        }
                        dto.Phone = (string?)answers[4]["phone_number"];
                        dto.Age = (int)answers[5]["text"];
                        dto.University = (string?)answers[6]["text"];
                        dto.ExperienceYear = (int)answers[7]["number"];

                        customerDtos.Add(dto);
                        customers = mapper.Map<List<CustomerDto>, List<Customer>>(customerDtos);
                        
                    }
                    await customerRepository.UpdateCustomerDataFromTypeform(customers);

                    return customerDtos;
                }
            }

            return await Task.FromResult<List<CustomerDto>>(new List<CustomerDto>());
        }
    }
}
