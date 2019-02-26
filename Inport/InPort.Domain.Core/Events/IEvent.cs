using System;

namespace InPort.Domain.Core.Events
{
    public interface IEvent: IMessage
    {
        DateTime Timestamp { get; }
    }
}