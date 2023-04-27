using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Parlem.Aplication.Dtos;
using Parlem.Aplication.Interfaces;
using Parlem.Aplication.Specifications;
using Parlem.Aplication.Wrappers;
using System.Text;

namespace Parlem.Aplication.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<List<CustomerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string DocNum { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string FamilyName1 { get; set; }
        public string Phone { get; set; }

        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<List<CustomerDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllCustomersQueryHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;

            }

            public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customersFilter = _mapper.Map<GetAllClientesFilter>(request);

                var customersList = await _repositoryAsync.ListAsync(new PagedCustomerSpecification(customersFilter));
             
                    var customersListDtos = _mapper.Map<List<CustomerDto>>(customersList);
                    return new PagedResponse<List<CustomerDto>>(customersListDtos, request.PageNumber, request.PageSize);

            }
        }

    }

}
