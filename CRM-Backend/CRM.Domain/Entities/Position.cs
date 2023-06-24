using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string? Name { get; set; }
        public int Score { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
