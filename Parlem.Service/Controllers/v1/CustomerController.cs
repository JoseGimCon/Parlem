using Microsoft.AspNetCore.Mvc;
using Parlem.Aplication.Features.Customer.Commands.CreateCustomerCommand;
using Parlem.Aplication.Features.Customer.Commands.DeleteCustomerCommand;
using Parlem.Aplication.Features.Customer.Commands.UpdateCustomerCommand;
using Parlem.Aplication.Features.Customer.Queries.GetAllCustomers;
using Parlem.Aplication.Features.Customer.Queries.GetCustomerById;

namespace Parlem.Service.Controllers.V1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllClientesFilter filter)
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                DocNum = filter.DocNum,
                Email = filter.Email,
                GivenName = filter.GivenName,
                FamilyName1 = filter.FamilyName1,
                Phone = filter.Phone,
            }));
        }

        [HttpPost]
        public async Task <IActionResult> Create(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerCommand() { Id = id }));
        }
    }
}
