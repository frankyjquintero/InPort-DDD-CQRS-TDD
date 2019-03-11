using System;
using System.Threading;
using System.Threading.Tasks;
using InPort.Aplication.Core.Exceptions;
using InPort.Aplication.Customers.Commands.CreateCustomer;
using InPort.Aplication.Customers.Commands.DeleteCustomer;
using InPort.Aplication.Test.Base;
using InPort.Domain;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Notifications;
using MediatR;
using Shouldly;
using Xunit;

namespace InPort.Aplication.Test.CustomerTest.Commands
{

    [Collection("QueryCollection")]
    public class DeleteCustomerHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _bus;
        private readonly INotificationHandler<DomainNotification> _notifications;
        private readonly DeleteCustomerCommandValidator _validator;

        public DeleteCustomerHandlerTest(QueryTestFixture fixture)
        {
            _unitOfWork = fixture.UnitOfWork;
            _bus = fixture.Bus;
            _notifications = fixture.Notifications;
            _validator = new DeleteCustomerCommandValidator();
        }
        [Fact]
        public async Task DeleteCustomerTaskOk()
        {
            // Arrange 

            DeleteCustomerCommandHandler commandHandler = new DeleteCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            Guid customerId = new Guid("43A38AC8-EAA9-4DF0-981F-2685882C7C45");
            DeleteCustomerCommand command = new DeleteCustomerCommand()
            {
                Id = customerId
            };
            _validator.Validate(command).IsValid.ShouldBeTrue();
            // Act 
            Unit responseUnit = await commandHandler.Handle(command, CancellationToken.None);
            Customer customer = _unitOfWork.Repository.CustomerRepository.SingleOrDefault(e => e.Id == customerId);
            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(customerId);
            customer.IsEnabled.ShouldBe(false);

        }
        [Fact]
        public void DeleteCustomerTaskFailExceptionNotFoundCustomer()
        {
            // Arrange 

            DeleteCustomerCommandHandler commandHandler = new DeleteCustomerCommandHandler(_unitOfWork, _bus, _notifications);
            Guid customerId = new Guid("4AA38AC8-EAA9-4DF0-981F-2685882C7C45");
            DeleteCustomerCommand command = new DeleteCustomerCommand()
            {
                Id = customerId
            };
            _validator.Validate(command).IsValid.ShouldBeTrue();
            // Act 
            Should.Throw<NotFoundException>(async () =>
            {
                Unit responseUnit = await commandHandler.Handle(command, CancellationToken.None);
            });


        }
    }
}
