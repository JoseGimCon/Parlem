using AutoMapper;
using MediatR;
using Parlem.Aplication.Dtos;
using Parlem.Aplication.Interfaces;
using Parlem.Aplication.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
    {
        public int Id { get; set; }
        public class GetClienteByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetClienteByIdQueryHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var cliente = await _repositoryAsync.GetByIdAsync(request.Id);
                if (cliente == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
                else
                {
                    var customerDto = _mapper.Map<CustomerDto>(cliente);
                    return new Response<CustomerDto>(customerDto);
                }

            }
        }
    }
}
