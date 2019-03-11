using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Commands;
using InPort.Aplication.Core.Exceptions;
using InPort.Aplication.Customers.Events;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Notifications;
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

        public async Task<Unit> Handle(DeleteCustomerCommand message, CancellationToken cancellationToken)
        {
            
            var entity = await Uow.Repository.CustomerRepository
                .SingleAsync(c => c.Id == message.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), message.Id);

            entity.Disable();

            Uow.Repository.CustomerRepository.Update(entity);
            await Uow.SaveChangesAsync();

            await Bus.Publish(new CustomerDeletedEvent(message.Id), cancellationToken);

            return Unit.Value;
        }


    }
}
