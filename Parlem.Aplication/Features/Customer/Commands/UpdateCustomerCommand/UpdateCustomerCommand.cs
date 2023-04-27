using AutoMapper;
using MediatR;
using Parlem.Aplication.Interfaces;
using Parlem.Aplication.Wrappers;
using System;

namespace Parlem.Aplication.Features.Customer.Commands.UpdateCustomerCommand
{

    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string FamilyName1 { get; set; }
        public string Phone { get; set; }
    }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsinc, IMapper mapper)
        {
            _repositoryAsync = repositoryAsinc;
            _mapper = mapper;
        }
       

        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _repositoryAsync.GetByIdAsync(request.Id);
            if (data == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado {request.Id}");
            }
            else
            {
                data.DocType = request.DocType;
                data.DocNum = request.DocNum;
                data.Email = request.Email;
                data.GivenName = request.GivenName;
                data.FamilyName1 = request.FamilyName1;
                data.Phone = request.Phone;

                await _repositoryAsync.UpdateAsync(data);

                return new Response<int>(data.Id);

            }
        }
    }
}
