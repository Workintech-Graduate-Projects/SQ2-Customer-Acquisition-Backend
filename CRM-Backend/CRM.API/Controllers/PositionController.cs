using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        //private readonly ApplicationDbContext applicationDbContext;

        //public PositionController(ApplicationDbContext applicationDbContext)
        //{
        //    this.applicationDbContext = applicationDbContext;
        //}
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var positions = applicationDbContext.Positions.ToListAsync();
        //    return Ok(positions);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add()
        //{
        //    Position position = new Position();
        //    if (position != null) {

        //        position.Id = 1;
        //        position.Name = "Senior";
        //        position.Score = 70;
          
        //    }
        //await applicationDbContext.Positions.AddAsync(position);
        //await applicationDbContext.SaveChangesAsync();
        //return Ok();
        //}

        //[HttpDelete("{id}")]

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var position = await applicationDbContext.Positions.FirstOrDefaultAsync(i => i.Id == id);
        //    applicationDbContext.Remove(position);

        //    await applicationDbContext.SaveChangesAsync();
        //    return Ok();  

        //}

        //[HttpPut]
        //public async Task<IActionResult> Update()
        //{
        //    var position = await applicationDbContext.Positions.FirstOrDefaultAsync();
        //    if (position != null)
        //    {
        //        position.Name = "Junior";
        //        position.Score = 50;

        //        applicationDbContext.Positions.Update(position);
        //    }
        //    await applicationDbContext.SaveChangesAsync();
        //    return Ok();

        //}
    }
}

