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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.typeform.com/forms/gWvnKsCW/responses");
            request.Headers.Add("Authorization", "Bearer tfp_6gc41itur7629WD6hmdMcrt8dzrRbPLXAK1WkS52mKaA_3mPHXKcv6CmQ7j");
            request.Method = "GET";
            List<Customer> customers = new();
            List<CustomerDto> customerDtos = new();

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
                    JObject item = items[0].Value<JObject>();
                    JArray answers = item["answers"].Value<JArray>();

                    foreach (var answer in answers)
                    {
                        string type = answer["type"].Value<string>();
                        string text = answer["text"].Value<string>();
                        JObject field = answer["field"].Value<JObject>();
                        string reff = field["ref"].Value<string>();

                        
                    }



                    if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
                    {
                        JsonArray jsonArray = jsonDocument.RootElement.EnumerateArray().ToArray();

                        List<CustomerDto> allCustomerDtos = new();

                        foreach (JsonElement jsonElement in jsonArray)
                        {
                            allCustomerDtos.Add(jsonElement);
                        }
                    }

                }
            }



            //customerRepository.UpdateCustomerDataFromTypeform(data)


            return await Task.FromResult<List<CustomerDto>>(new List<CustomerDto>());
        }
    }
}
