using InPort.Domain.Core.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InPort.Aplication
{
    public class EventSourcingHandler<TNotification> : INotificationHandler<TNotification>
     where TNotification : Event
    {
        private readonly IEventStore _eventStore;
        public EventSourcingHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Task Handle(TNotification @event, CancellationToken cancellationToken)
        {
            if (!@event.EventType.Equals("DomainNotification"))
                _eventStore?.Save(@event);               

            return Task.CompletedTask;
        }
    }
}
