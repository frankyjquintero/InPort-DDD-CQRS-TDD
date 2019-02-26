using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using InPort.Domain.Core.Commands;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core;
using InPort.Domain.Core.Notifications;
using InPort.Aplication.Core.Commands;

namespace InPort.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : CommandHandler, IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetAsync(request.Id);

            if (entity == null)
            {
               await Bus.RaiseEvent(new DomainNotification(request.MessageType, "The customer NotFoundException."));
            }

            var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing orders associated with this customer.");
            }

            _context.Customers.Remove(entity);
            await _customerRepository.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
