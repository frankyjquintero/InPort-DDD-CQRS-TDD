using System;
using MediatR;

namespace InPort.Domain.Core.Events
{
    public abstract class Event : INotification, IEvent
    {
        
        public string EventType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected Event(Guid aggregateId)
        {
            AggregateId = aggregateId;
            EventType = GetType().Name;
            Timestamp = DateTime.Now;
        }
      

    }
}