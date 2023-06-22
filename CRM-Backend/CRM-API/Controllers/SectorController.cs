using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_DataAccess.Context;
using CRM_DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SectorController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sectors = await applicationDbContext.Sectors.ToListAsync();
            return Ok(sectors);
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            Sector sector = new Sector()
            {
               Name = "Bilgi Teknolojileri ve Medya",
               Group = "A",
               Score = 80,
            };

            await applicationDbContext.Sectors.AddAsync(sector);
            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }
        //[HttpPut]
        //public async Task<IActionResult> Put() { };
    }
}
