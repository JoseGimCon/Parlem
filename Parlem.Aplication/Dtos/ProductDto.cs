using Parlem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }
        public int NumeracioTerminal { get; set; }
        public DateTime SoldAt { get; set; }
        public virtual List<Customer> CustomersDtos { get; set; }
    }
}
