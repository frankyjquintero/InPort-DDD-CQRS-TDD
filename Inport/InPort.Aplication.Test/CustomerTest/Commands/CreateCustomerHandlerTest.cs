using System;
using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Exceptions;
using InPort.Aplication.Customers.Commands.CreateCustomer;
using InPort.Aplication.Test.Base;
using InPort.Domain;
using InPort.Domain.Core.Notifications;
using MediatR;
using Shouldly;
using Xunit;

namespace InPort.Aplication.Test.CustomerTest.Commands
{
    [Collection("QueryCollection")]
    public class CreateCustomerHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _bus;
        private readonly INotificationHandler<DomainNotification> _notifications;
        private readonly CreateCustomerCommandValidator _validator;

        public CreateCustomerHandlerTest(QueryTestFixture fixture)
        {
            _unitOfWork = fixture.UnitOfWork;
            _bus = fixture.Bus;
            _notifications = fixture.Notifications;
            _validator = new CreateCustomerCommandValidator();
        }
        [Fact]
        public async Task CreateCustomerTaskOk()
        {
            // Arrange 

            CreateCustomerCommandHandler commandHandler = new CreateCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            CreateCustomerCommand command = new CreateCustomerCommand()
            {
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
           var customerId = await commandHandler.Handle(command, CancellationToken.None);
           var customer =  _unitOfWork.Repository.CustomerRepository.SingleOrDefault(e => e.Id == customerId);
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
        public void CreateCustomerTaskFailExceptionNotFoundCountry()
        {
            // Arrange 
            CreateCustomerCommandHandler commandHandler = new CreateCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            CreateCustomerCommand command = new CreateCustomerCommand()
            {
                FirstName = "Franky",
                LastName = "Quintero",
                Telephone = "573004436932",
                Company = "UPC",
                Email = "Email@mail.com",
                AddressCity = "La Jagua de Ibirico",
                AddressZipCode = "203020",
                AddressLine1 = "B.Santander",
                AddressLine2 = "",
                CountryId = new Guid("22BB805F-40A4-4C37-AA96-B7945C8C385C")
            };
            _validator.Validate(command).IsValid.ShouldBeTrue();
            // Act 
            Should.Throw<NotFoundException>(async () => {
                var customerId = await commandHandler.Handle(command, CancellationToken.None);
            });
           

        }
    }
}
