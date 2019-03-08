using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Commands;
using InPort.Aplication.Core.Exceptions;
using InPort.Aplication.Customers.Events;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
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
            var country = await Uow.Repository.CountryRepository
                .SingleAsync(c => c.Id == message.CountryId);

            if (country == null)
                throw new NotFoundException(nameof(Country), message.CountryId);

            var address = new  Address(message.AddressCity,message.AddressZipCode, message.AddressLine1, message.AddressLine2);

            var customer = CustomerFactory.CreateCustomer(message.FirstName, message.LastName, message.Telephone, message.Company, message.Email, country, address);

            //if (_customerRepository.GetByEmail(customer.Email) != null)
            //{
            //    await Bus.RaiseEvent(new DomainNotification(message.MessageType, "El correo electrónico del cliente ya ha sido tomado."));
            //    return Unit.Value;
            //}

            await Uow.Repository.CountryRepository.AddAsync(country);


            if (await Uow.SaveChangesAsync())
            {
               await Bus.Publish(new CustomerCreatedEvent(customer.Id), cancellationToken);
            }

            return Unit.Value;
        }

    }
    
}
