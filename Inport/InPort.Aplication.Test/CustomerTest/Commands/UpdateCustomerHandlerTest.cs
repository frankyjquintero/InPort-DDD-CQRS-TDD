using InPort.Aplication.Core.Exceptions;
using InPort.Aplication.Customers.Commands.UpdateCustomer;
using InPort.Aplication.Test.Base;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Notifications;
using MediatR;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InPort.Aplication.Test.CustomerTest.Commands
{

    [Collection("QueryCollection")]
    public class UpdateCustomerHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _bus;
        private readonly INotificationHandler<DomainNotification> _notifications;
        private readonly UpdateCustomerCommandValidator _validator;

        public UpdateCustomerHandlerTest(QueryTestFixture fixture)
        {
            _unitOfWork = fixture.UnitOfWork;
            _bus = fixture.Bus;
            _notifications = fixture.Notifications;
            _validator = new UpdateCustomerCommandValidator();
        }
        [Fact]
        public async Task UpdateCustomerTaskOk()
        {
            // Arrange 

            UpdateCustomerCommandHandler commandHandler = new UpdateCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            Guid customerId = new Guid("43A38AC8-EAA9-4DF0-981F-2685882C7C45");
            // "Jhon", "Jhon", "+34617", "company", "Email@mail.com",spainCountry, new Address("Madrid", "280181", "Paseo de La finca", ""

            UpdateCustomerCommand command = new UpdateCustomerCommand()
            {
                Id = customerId,
                FirstName = "Franky",
                LastName = "Quintero",
                Telephone = "573004436932",
                Company = "UPC",
                Email = "Email@mail.com",
                AddressCity = "La Jagua de Ibirico",
                AddressZipCode = "203020",
                AddressLine1 = "B.Santander",
                AddressLine2 = "",
                CountryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C")
            };
            _validator.Validate(command).IsValid.ShouldBeTrue();
            // Act 
            Unit responseUnit = await commandHandler.Handle(command, CancellationToken.None);
            Customer customer = _unitOfWork.Repository.CustomerRepository.SingleOrDefault(e => e.Id == customerId);
            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(customerId);
            customer.FirstName.ShouldBe("Franky");
            customer.LastName.ShouldBe("Quintero");
            customer.Telephone.ShouldBe("573004436932");
            customer.Company.ShouldBe("UPC");
            customer.Email.ShouldBe("Email@mail.com");
            customer.Address.City.ShouldBe("La Jagua de Ibirico");
            customer.Address.ZipCode.ShouldBe("203020");
            customer.Address.AddressLine1.ShouldBe("B.Santander");
            customer.Address.AddressLine2.ShouldBe("");
            customer.CountryId.ShouldBe(new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C"));

        }
        [Fact]
        public void UpdateCustomerTaskFailExceptionNotFoundCustomer()
        {
            // Arrange 

            UpdateCustomerCommandHandler commandHandler = new UpdateCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            Guid customerId = new Guid("30A38AC8-EAA9-4DF0-981F-2685882C7C45");
            // not found xD

            UpdateCustomerCommand command = new UpdateCustomerCommand()
            {
                Id = customerId,
                FirstName = "Franky",
                LastName = "Quintero",
                Telephone = "573004436932",
                Company = "UPC",
                Email = "Email@mail.com",
                AddressCity = "La Jagua de Ibirico",
                AddressZipCode = "203020",
                AddressLine1 = "B.Santander",
                AddressLine2 = "",
                CountryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C")
            };
            _validator.Validate(command).IsValid.ShouldBeTrue();

            // Act + Assert
            Should.Throw<NotFoundException>(async () =>
            {
                Unit responseUnit = await commandHandler.Handle(command, CancellationToken.None);
            });
        }
        [Fact]
        public void UpdateCustomerTaskFailExceptionNotFoundCountry()
        {
            // Arrange 

            UpdateCustomerCommandHandler commandHandler = new UpdateCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            Guid customerId = new Guid("43A38AC8-EAA9-4DF0-981F-2685882C7C45");
            // "Jhon", "Jhon", "+34617", "company", "Email@mail.com",spainCountry, new Address("Madrid", "280181", "Paseo de La finca", ""

            UpdateCustomerCommand command = new UpdateCustomerCommand()
            {
                Id = customerId,
                FirstName = "Franky",
                LastName = "Quintero",
                Telephone = "573004436932",
                Company = "UPC",
                Email = "Email@mail.com",
                AddressCity = "La Jagua de Ibirico",
                AddressZipCode = "203020",
                AddressLine1 = "B.Santander",
                AddressLine2 = "",
                CountryId = new Guid("30BB805F-40A4-4C37-AA96-B7945C8C385C") //Country not Found
            };
            
            _validator.Validate(command).IsValid.ShouldBeTrue();

            // Act + Assert
            Should.Throw<NotFoundException>(async () =>
            {
                Unit responseUnit = await commandHandler.Handle(command, CancellationToken.None);
            });


        }
    }
}
