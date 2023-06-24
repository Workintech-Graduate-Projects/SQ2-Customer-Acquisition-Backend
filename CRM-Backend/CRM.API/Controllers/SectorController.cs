using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        //private readonly ApplicationDbContext applicationDbContext;

        //public SectorController(ApplicationDbContext applicationDbContext)
        //{
        //    this.applicationDbContext = applicationDbContext;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add()
        //{
        //    Sector sector = new Sector()
        //    {
        //       Name = "Bilgi Teknolojileri ve Medya",
        //       Group = "A",
        //       Score = 80,
        //    };

        //    await applicationDbContext.Sectors.AddAsync(sector);
        //    await applicationDbContext.SaveChangesAsync();
        //    return Ok();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var sectors = await applicationDbContext.Sectors.ToListAsync();
        //    return Ok(sectors);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update()
        //{
        //    var sector = await applicationDbContext.Sectors.FirstOrDefaultAsync();
        //    if(sector != null)
        //    {
        //        sector.Name = "Tarım";
        //        sector.Group = "B";
        //        sector.Score = 70;



        //        applicationDbContext.Sectors.Update(sector);
        //    }
        //    await applicationDbContext.SaveChangesAsync();
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var sector = await applicationDbContext.Sectors.FirstOrDefaultAsync(i => i.Id == id);
        //    if (sector != null)
        //    {
        //        applicationDbContext.Sectors.Remove(sector);
        //    }
        //    await applicationDbContext.SaveChangesAsync();
        //    return Ok();
        //}

    }
}
