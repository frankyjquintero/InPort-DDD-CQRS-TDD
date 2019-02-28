
using InPort.Domain.Core.Commands;
using InPort.Domain.Core.Events;
using InPort.Domain.Core.Querys;
using MediatR;
using System.Threading.Tasks;

namespace InPort.Domain.Core
{
    public interface IMediatorHandler
    {
        Task<Unit> SendCommand<T>(T command) where T : Command;
        Task<Unit> SendCommandQuery<T>(T command) where T : IRequest;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
