using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
