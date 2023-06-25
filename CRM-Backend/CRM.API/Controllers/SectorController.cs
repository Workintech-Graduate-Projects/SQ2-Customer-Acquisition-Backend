using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService sectorService;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }

        [HttpPost]
        public async Task<ActionResult<SectorDto>> Add(SectorDto sectorDto)
        {
            try
            {
                var createdSector = await sectorService.AddAsync(sectorDto);
                return createdSector;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SectorDto>>> GetAllSectors()
        {
            try
            {
                var sectors = await sectorService.GetAll();

                return sectors;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SectorDto>> GetSectorById(int id)
        {
            try
            {
                var sector = await sectorService.GetById(id);

                return sector;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<SectorDto>> Update(SectorDto sectorDto)
        {
            try
            {
                var updatedSector = await sectorService.Update(sectorDto);

                return updatedSector;
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }


    }
}
