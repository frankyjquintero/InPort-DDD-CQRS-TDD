using System;

namespace InPort.Domain.Core.Events
{
    public interface IEvent
    {
        DateTime Timestamp { get; }
    }
}