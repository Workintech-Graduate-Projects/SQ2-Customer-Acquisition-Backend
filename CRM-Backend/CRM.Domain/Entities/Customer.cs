using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Customer
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
        public Sector? Sector { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
    }
}
