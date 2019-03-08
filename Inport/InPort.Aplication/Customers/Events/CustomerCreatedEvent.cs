using System;
using System.Threading;
using System.Threading.Tasks;
using InPort.Domain.Core.Events;
using MediatR;

namespace InPort.Aplication.Customers.Events
{
    public class CustomerCreatedEvent : Event
    {
        public Guid CustomerId { get; private set; }
        public string FirstName { get; set; }

        public CustomerCreatedEvent(Guid customerId) :
            base(customerId)
        {
            CustomerId = customerId;
        }
    }
    public class CustomerCreatedHandler : INotificationHandler<CustomerCreatedEvent>
    {
       

        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("mmmm1");
            ////await _notification.SendAsync(new Message());
        }
    }
}
