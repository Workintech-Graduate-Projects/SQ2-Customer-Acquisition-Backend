using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Repositories;
using CRM.Application.Interfaces.Services;
using CRM.Domain.Entities;
using Newtonsoft.Json;
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

        public async Task<CustomerDto> SendCustomerDataToPipedrive(CustomerDto entity)
        {
            Position position = await positionRepository.GetById(entity.PositionId);
            Sector sector = await sectorRepository.GetById(entity.SectorId);

            var apiUrl = "https://api.pipedrive.com/v1/leads?api_token=81dbd3b8f7a7c4eb207d2ad52ac10d12f72ebe36";

            JObject body = new JObject();

            body["organization_id"]  = 1;
            body["owner_id"] = 15178107;
            body["title"] = "backend-test";
            body["24afe5b2e1fcc1280f8fe18cc638f559934d7a9d"] = 234.ToString(); //credit score
            body["b08cc0468b6d44eb79bcf9afd9cc56705a19c518"] = 1.ToString(); //queue value
            body["b301dff3f2b3c496151e6d69689004d629439a9e"] = "Düşük"; // risk value
            body["407b288c044cb5b0e4fd1298c38874dbcc6fedd1"] = entity.FirstName;
            body["98337799a3ea773fc6409b8885a3bf3420ef59ff"] = entity.LastName;
            body["736730b10f2381ce3719df826e23616f7544ed9d"] = position.Name;
            body["e56c2b48b88f2e786b212b2ddf33e911a4729aa2"] = sector.Name;
            body["c56b58fc5fbd0b4142423bc8cede2c72c20eb23d"] = entity.Phone;
            body["67c531f5476fc3770e471dc4dafbecb6fc412b53"] = entity.Age.ToString();
            body["8987d4eec0ae130efc458d730c73a1dabe6c82e6"] = entity.University;

            //var jsonPayload = JsonConvert.SerializeObject(body);

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            //request.Headers.Add("Authorization", "API Key 81dbd3b8f7a7c4eb207d2ad52ac10d12f72ebe36");
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(body);
                streamWriter.Flush();
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseContent = streamReader.ReadToEnd();
                    }
                }

                entity.IsSentToPipedrive = true;
                Customer customer = mapper.Map<CustomerDto, Customer>(entity);
                await customerRepository.Update(customer);
                
            }
            catch (WebException ex)
            {
                var errorResponse = (HttpWebResponse)ex.Response;
                if (errorResponse != null)
                {
                    using (var streamReader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        var errorContent = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that occurred during the request
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return entity;
            
        }

        public async Task<CustomerDto> Update(CustomerDto entity)
        {
            Customer customer = mapper.Map<CustomerDto, Customer>(entity);
            await customerRepository.Update(customer);

            return entity;
        }

        public async Task<List<CustomerDto>> AddCustomerDataFromTypeform()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.typeform.com/forms/htBMgwwF/responses");
            request.Headers.Add("Authorization", "Bearer tfp_GBXtzBzbQCR6jehN7QxEEnTcBcSPL6UaxECRmwUcUrVq_3mJrwXQcHAPMcv");
            request.Method = "GET";

            List<Customer> customersList = new();
            List<CustomerDto> customerDtosList = new();
            Dictionary<string, int> sectors = await sectorRepository.GetSectorNamesAndIds();
            Dictionary<string, int> positions = await positionRepository.GetPositionNamesAndIds();
            List<string> dbCustomerLandingIds = await customerRepository.GetAllLandingIds();

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
                        dto.LandingId = (string)item["landing_id"];
                        dto.IsSentToPipedrive = false;

                        customerDtosList.Add(dto);
                        Customer customer = mapper.Map<CustomerDto, Customer>(dto);

                        if (!dbCustomerLandingIds.Contains(customer.LandingId))
                            customersList.Add(customer);
                    }

                    await customerRepository.AddRangeAsync(customersList);

                    return customerDtosList;

                }
            }

            
        }
    }
}
