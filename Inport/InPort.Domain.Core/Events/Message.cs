using System;
using MediatR;

namespace InPort.Domain.Core.Events
{
    public abstract class Message : IRequest, IMessage
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}