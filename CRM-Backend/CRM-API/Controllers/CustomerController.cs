using CRM_DataAccess.Context;
using CRM_DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer = await applicationDbContext.Customers.ToListAsync();

            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            

            Customer cs = new Customer()
            {
                FirstName = "rumeysa",
                LastName = "ileri",
                ExperienceYear = 5,
                Age = 28,
                SectorId=1,
                PositionId=1
            };

            await applicationDbContext.Customers.AddAsync(cs);
            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
