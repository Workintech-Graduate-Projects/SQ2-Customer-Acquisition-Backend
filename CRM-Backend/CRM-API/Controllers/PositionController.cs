using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_DataAccess.Context;
using CRM_DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly ApplicationDbContext applicatonDbContext;

        public PositionController(ApplicationDbContext applicationDbContext)
        {
            this.applicatonDbContext = applicatonDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var positions = applicatonDbContext.Positions.ToListAsync();
            return Ok(positions);
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            Position position = new Position();
            return Ok();
        }
    }
}

