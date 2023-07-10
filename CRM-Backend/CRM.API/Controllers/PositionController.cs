using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
using CRM_Common.Attributes;
using CRM_Common.Enums;
using CRM_Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        public async Task<ActionResult<List<PositionDto>>> GetAllPositions()
        {
            try
            {

                var positions = await positionService.GetAll();
                return positions;
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDto>> GetPositionById(int id)
        {
            try
            {
                var position = await positionService.GetById(id);
                return position;
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PositionDto>> Add(PositionDto positionDto)
        {

            try
            {

                var createdPosition = await positionService.AddAsync(positionDto);
                return createdPosition;
            }
            catch (Exception e)
            {
                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }


        }

        [HttpPut]
        public async Task<ActionResult<PositionDto>> Update(PositionDto positionDto)
        {
            try
            {
                var updatedPosition = await positionService.Update(positionDto);
                return updatedPosition;
            }
            catch (Exception e)
            {

                return Problem($"Hata Var!!!! {e.Message} {e.StackTrace}");
            }

        }
    }
}

