using Parlem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }
        public int NumeracioTerminal { get; set; }
        public DateTime SoldAt { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
