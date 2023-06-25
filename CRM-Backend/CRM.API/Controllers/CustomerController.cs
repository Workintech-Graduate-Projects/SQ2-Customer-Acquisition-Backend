using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
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
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var allCustomers = await customerService.GetAll();

                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {

            try
            {
                await customerService.AddAsync(customerDto);

                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            try
            {
                await customerService.Update(customerDto);

                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }
    }
}
