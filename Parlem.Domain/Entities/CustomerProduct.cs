using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Domain.Entities
{
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
