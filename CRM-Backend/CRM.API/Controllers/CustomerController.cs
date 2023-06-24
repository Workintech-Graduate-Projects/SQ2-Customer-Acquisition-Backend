using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ApplicationDbContext applicationDbContext;

        //public CustomerController(ApplicationDbContext applicationDbContext)
        //{
        //    this.applicationDbContext = applicationDbContext;
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAllCustomers()
        //{

        //    var allCustomers = await applicationDbContext.Customers.ToListAsync();

        //    var lastNameFilter = await applicationDbContext.Customers
        //        .Where(i => i.LastName == "İleri")
        //        .Where(i => i.FirstName != "rumeysa")
        //        .ToListAsync();

        //    return Ok(allCustomers);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add()
        //{

        //    Customer cs = new Customer()
        //    {
        //        FirstName = "rumeysa",
        //        LastName = "ileri",
        //        ExperienceYear = 5,
        //        Age = 28,
        //        SectorId = 1,
        //        PositionId = 1
        //    };

        //    await applicationDbContext.Customers.AddAsync(cs);
        //    await applicationDbContext.SaveChangesAsync();

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var customer = await applicationDbContext.Customers.FirstOrDefaultAsync(i => i.Id == id);

        //    if (customer != null)
        //    {
        //        applicationDbContext.Customers.Remove(customer);
        //    }

        //    await applicationDbContext.SaveChangesAsync();

        //    return Ok();
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update()
        //{
        //    var customer = await applicationDbContext.Customers.FirstOrDefaultAsync();

        //    if (customer != null)
        //    {
        //        customer.FirstName = "tanju";
        //        customer.LastName = "ileri";

        //        applicationDbContext.Customers.Update(customer);
        //    }

        //    await applicationDbContext.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
