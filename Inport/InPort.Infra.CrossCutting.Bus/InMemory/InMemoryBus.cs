using InPort.Domain.Core;
using InPort.Domain.Core.Events;
using InPort.Domain.Core.Querys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InPort.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        //public Task<Unit> SendCommand<T>(T command) where T : Command
        //{
        //    //return _mediator.Send(command);
        //}

        //public Task<Unit> SendCommandQuery<T>(T command) where T : IRequest
        //{
        //    return _mediator.Send(command);
        //}

        //public Task RaiseEvent<T>(T @event) where T : Event
        //{
        //    if (!@event.EventType.Equals("DomainNotification"))
        //        _eventStore?.Save(@event);

        //    return _mediator.Publish(@event);
        //}
    }
}
