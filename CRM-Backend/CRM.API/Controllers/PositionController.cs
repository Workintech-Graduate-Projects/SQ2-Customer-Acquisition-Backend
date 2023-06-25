using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService positionService;

        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPositions()
        {
            try
            {
                var positions = await positionService.GetAll();
                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var positions = await positionService.GetById(id);
                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(PositionDto positionDto)
        {
            try
            {
                await positionService.AddAsync(positionDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update(PositionDto positionDto)
        {
            try
            {
                await positionService.Update(positionDto);
                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }

        }
    }
}

