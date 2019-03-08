using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Commands;
using InPort.Domain;
using InPort.Domain.Core.Notifications;
using InPort.Domain.Repositories;
using MediatR;

namespace InPort.Aplication.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : CommandHandler, IRequestHandler<CreateCustomerCommand, Unit>
    {

 
        public CreateCustomerCommandHandler(
                                      IUnitOfWork uow,
                                      IMediator bus,
                                      INotificationHandler<DomainNotification> notifications) 
            : base(uow, bus, notifications)
        {
        }

        public async Task<Unit> Handle(CreateCustomerCommand message, CancellationToken cancellationToken)
        {
            //var country = new Country();
            //var customer = CustomerFactory.CreateCustomer(message.FirstName, message.LastName, message.Telephone, message.Company,);

            //if (_customerRepository.GetByEmail(customer.Email) != null)
            //{
            //    await Bus.RaiseEvent(new DomainNotification(message.MessageType, "El correo electrónico del cliente ya ha sido tomado."));
            //    return Unit.Value;
            //}

            //_customerRepository.Add(customer);

            //if (Commit())
            //{
            //    Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            //}

            return Unit.Value;
        }

    }
    
}
