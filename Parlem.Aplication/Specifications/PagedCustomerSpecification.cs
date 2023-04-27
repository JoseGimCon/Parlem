using Ardalis.Specification;
using Parlem.Aplication.Features.Customer.Queries.GetAllCustomers;
using Parlem.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Specifications
{
    public class PagedCustomerSpecification : Specification<Customer>
    {
        public PagedCustomerSpecification(GetAllClientesFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.DocNum))
                Query.Search(x => x.DocNum, "%" + filter.DocNum + "%");

            if (!string.IsNullOrEmpty(filter.Email))
                Query.Search(x => x.Email, "%" + filter.Email + "%");

            if (!string.IsNullOrEmpty(filter.GivenName))
                Query.Search(x => x.GivenName, "%" + filter.GivenName + "%");

            if (!string.IsNullOrEmpty(filter.FamilyName1))
                Query.Search(x => x.FamilyName1, "%" + filter.FamilyName1 + "%");

            if (!string.IsNullOrEmpty(filter.Phone))
                Query.Search(x => x.Phone, "%" + filter.Phone + "%");
        }
    }
}
