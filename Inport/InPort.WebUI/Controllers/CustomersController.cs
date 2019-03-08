using InPort.Domain.Core;
using InPort.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using InPort.Aplication.Customers.Commands.CreateCustomer;
using InPort.Aplication.Customers.Commands.DeleteCustomer;
using InPort.Aplication.Customers.Commands.UpdateCustomer;
using InPort.Aplication.Customers.Queries.GetCustomerDetail;
using InPort.Aplication.Customers.Queries.GetCustomersList;

namespace InPort.WebUI.Controllers
{
    public class CustomersController : BaseController
    {
        public CustomersController(
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory,
            IMediator mediator) : base(notifications, mediator, loggerFactory.CreateLogger<CustomersController>())
        {

        }


        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<CustomersListViewModel>> GetAll()
        {
            return Ok(await _mediator.Send(new GetCustomersListQuery()));
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailModel>> Get(string id)
        {
            return Ok(await _mediator.Send(new GetCustomerDetailQuery { Id = id }));
        }

        // POST api/customers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateCustomerCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(string id, [FromBody]UpdateCustomerCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand{ Id = id });

            return NoContent();
        }
    }
}