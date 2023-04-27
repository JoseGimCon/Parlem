using Parlem.Aplication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllClientesFilter : RequestPaginationParams
    {
        public string? DocNum { get; set; }
        public string? Email { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName1 { get; set; }
        public string? Phone { get; set; }
    }
}
