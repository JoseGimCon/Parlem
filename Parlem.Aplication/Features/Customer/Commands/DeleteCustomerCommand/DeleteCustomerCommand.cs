using AutoMapper;
using MediatR;
using Parlem.Aplication.Interfaces;
using Parlem.Aplication.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Features.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsinc, IMapper mapper)
        {
            _repositoryAsync = repositoryAsinc;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _repositoryAsync.GetByIdAsync(request.Id);

            if (data == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(data);

                return new Response<int>(data.Id);
            }
        }
    }
}
