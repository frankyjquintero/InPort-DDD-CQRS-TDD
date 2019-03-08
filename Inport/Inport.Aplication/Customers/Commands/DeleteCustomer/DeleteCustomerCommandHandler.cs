using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Commands;
using InPort.Aplication.Core.Exceptions;
using InPort.Aplication.Customers.Events;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Notifications;
using InPort.Domain.Repositories;
using MediatR;

namespace InPort.Aplication.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : CommandHandler, IRequestHandler<DeleteCustomerCommand>
    {



        public DeleteCustomerCommandHandler(
                                      IUnitOfWork uow,
                                      IMediator bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await Bus.Publish(new CustomerDeletedEvent(request.Id), cancellationToken);

            throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing orders associated with this customer.");
            //var entity = await _customerRepository.GetAsync(request.Id);

            //if (entity == null)
            //{
            //   await Bus.RaiseEvent(new DomainNotification(request.MessageType, "The customer NotFoundException."));
            //}

            //var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            //if (hasOrders)
            //{
            //    throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing orders associated with this customer.");
            //}

            //_context.Customers.Remove(entity);
            //await _customerRepository.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
