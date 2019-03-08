using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Commands;
using InPort.Aplication.Core.Exceptions;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Notifications;
using InPort.Infra.Data.Context;
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

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await Uow.Repository.CustomerRepository
                .SingleAsync(c => c.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            var address = new Address(request.AddressCity, request.AddressZipCode, request.AddressLine1,
                request.AddressLine2);
            entity.Address = address;

            entity.Company = request.Company;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            var country = await Uow.Repository.CountryRepository
                .SingleAsync(c => c.Id == request.CountryId);
            if (country == null)
                throw new NotFoundException(nameof(Country), request.Id);

            entity.SetTheCountryForThisCustomer(country);

            entity.Company = request.Company;
            entity.Email = request.Email;
            entity.Telephone = request.Telephone;
            var picture = new Picture
            {
                RawPhoto = request.PictureByte
            };
            entity.ChangePicture(picture);

            Uow.Repository.CustomerRepository.Update(entity);
            

            await Uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
