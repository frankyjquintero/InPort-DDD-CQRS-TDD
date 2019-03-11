using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Commands;
using InPort.Aplication.Core.Exceptions;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Notifications;
using MediatR;

namespace InPort.Aplication.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : CommandHandler, IRequestHandler<UpdateCustomerCommand, Unit>
    {


        public UpdateCustomerCommandHandler(
            IUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public async Task<Unit> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            var entity = await Uow.Repository.CustomerRepository
                .SingleAsync(c => c.Id == message.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), message.Id);

            var address = new Address(message.AddressCity, message.AddressZipCode, message.AddressLine1,
                message.AddressLine2);
            entity.Address = address;

            entity.Company = message.Company;
            entity.FirstName = message.FirstName;
            entity.LastName = message.LastName;

            var country = await Uow.Repository.CountryRepository
                .SingleAsync(c => c.Id == message.CountryId);
            if (country == null)
                throw new NotFoundException(nameof(Country), message.CountryId);

            entity.SetTheCountryForThisCustomer(country);

            entity.Company = message.Company;
            entity.Email = message.Email;
            entity.Telephone = message.Telephone;
            var picture = new Picture
            {
                RawPhoto = message.PictureByte
            };
            entity.ChangePicture(picture);

            Uow.Repository.CustomerRepository.Update(entity);
            

            await Uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
