using InPort.Aplication.Core;
using InPort.Aplication.Core.Interfaces;
using InPort.Domain.Core.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InPort.Application.Customers.Events
{
    public class CustomerCreated : Event
    {
        public string CustomerId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
        {
            private readonly INotificationService _notification;

            public CustomerCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
            {
                ////await _notification.SendAsync(new Message());
            }
        }
    }
}
