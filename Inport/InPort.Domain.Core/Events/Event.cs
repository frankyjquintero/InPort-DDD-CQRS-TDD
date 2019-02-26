using System;
using MediatR;

namespace InPort.Domain.Core.Events
{
    public abstract class Event : Message, INotification, IEvent
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}