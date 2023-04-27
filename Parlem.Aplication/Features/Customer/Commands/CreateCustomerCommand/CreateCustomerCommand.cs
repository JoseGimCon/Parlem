using AutoMapper;
using MediatR;
using Parlem.Aplication.Interfaces;
using Parlem.Aplication.Wrappers;

namespace Parlem.Aplication.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string FamilyName1 { get; set; }
        public string Phone { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsinc, IMapper mapper)
        {
            _repositoryAsync = repositoryAsinc;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
                var newCustomer = _mapper.Map<Domain.Entities.Customer>(request);
                var data = await _repositoryAsync.AddAsync(newCustomer);
            
            return new Response<int>(data.Id);
        }
    }
}
