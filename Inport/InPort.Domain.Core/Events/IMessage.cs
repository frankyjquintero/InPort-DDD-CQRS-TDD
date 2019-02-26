using System;

namespace InPort.Domain.Core.Events
{
    public interface IMessage
    {
        Guid AggregateId { get; }
        string MessageType { get; }
    }
}