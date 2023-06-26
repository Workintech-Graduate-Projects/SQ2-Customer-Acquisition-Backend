using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
using CRM.Application.Services;
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
        //[Route("get-all-customers")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var allCustomers = await customerService.GetAll();

                return allCustomers;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpGet]
        [Route("update-customer-data-from-typeform")]
        public async Task<ActionResult<List<CustomerDto>>> UpdateCustomerDataFromTypeform()
        {
            try
            {
                var typeformCustomersResponses = await customerService.UpdateCustomerDataFromTypeform();

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
