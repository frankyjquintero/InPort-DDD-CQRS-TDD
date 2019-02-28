using System;

namespace InPort.Domain.Core.Events
{
    public class StoredEvent 
    {
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            EventType = theEvent.EventType;
            Timestamp = theEvent.Timestamp;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; private set; }
        public string EventType { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Data { get; private set; }

        public string User { get; private set; }
    }
}