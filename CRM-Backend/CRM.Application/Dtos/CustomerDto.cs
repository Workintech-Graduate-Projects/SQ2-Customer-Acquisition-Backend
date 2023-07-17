using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int ExperienceYear { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public string? University { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public int SectorScore { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int PositionScore { get; set; }
        public string? LandingId { get; set; }
        public bool IsSentToPipedrive { get; set; }
    }
}
