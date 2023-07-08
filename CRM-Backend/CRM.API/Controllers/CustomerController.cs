using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
using CRM.Application.Services;
using CRM_Common.Attributes;
using CRM_Common.Enums;
using CRM_Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Authorization(new[] { AuthorizationRole.Admin, AuthorizationRole.Employee })]
        //[Route("get-all-customers")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers(string token)
        {
            try
            {
                string role = TokenHelper.GetUserRoleFromJwtToken(token);

                if (string.IsNullOrWhiteSpace(role) || !AuthorizationHelper.HasAuthority(role, this.GetType(), "GetAllCustomers"))
                    throw new Exception("User Don't have Authority to use this API");

                var allCustomers = await customerService.GetAll();

                return allCustomers;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpGet]
        [Route("add-customer-data-from-typeform")]
        public async Task<ActionResult<List<CustomerDto>>> AddCustomerDataFromTypeform()
        {
            try
            {

                var typeformCustomersResponses = await customerService.AddCustomerDataFromTypeform();

                return typeformCustomersResponses;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpGet("{id}")]
        //[Route("get-customer-by-id")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            try
            {
                var customer = await customerService.GetById(id);
                return customer;
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpPost]
        //[Route("create-customer")]
        public async Task<ActionResult<CustomerDto>> Add(CustomerDto customerDto)
        {

            try
            {
                var createdCustomer = await customerService.AddAsync(customerDto);

                return createdCustomer;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpPost]
        [Route("send-customer-data-to-pipedrive")]
        public async Task<ActionResult<CustomerDto>> SendCustomerDataToPipedrive(CustomerDto customerDto)
        {

            try
            {
                await customerService.SendCustomerDataToPipedrive(customerDto);
                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpPut]
        //[Route("update-customer")]
        public async Task<ActionResult<CustomerDto>> Update(CustomerDto customerDto)
        {
            try
            {
                var updatedCustomer = await customerService.Update(customerDto);

                return updatedCustomer;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }
    }
}
