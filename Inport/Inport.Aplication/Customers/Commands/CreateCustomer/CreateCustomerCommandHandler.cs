using System.Threading;
using System.Threading.Tasks;
using MediatR;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core;
using InPort.Domain.Core.Notifications;
using InPort.Aplication.Core.Commands;
using System;

namespace InPort.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : CommandHandler, IRequestHandler<CreateCustomerCommand, Unit>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository; 
            Bus = bus;
        }

        public async Task<Unit> Handle(CreateCustomerCommand message, CancellationToken cancellationToken)
        {

            //var customer = CustomerFactory.CreateCustomer(message.Name, message.Name, message.Email, message.BirthDate);

            //if (_customerRepository.GetByEmail(customer.Email) != null)
            //{
            //  await   Bus.RaiseEvent(new DomainNotification(message.MessageType, "El correo electrónico del cliente ya ha sido tomado."));
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
