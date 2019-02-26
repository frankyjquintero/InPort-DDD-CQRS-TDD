
using InPort.Domain.Core.Commands;
using InPort.Domain.Core.Events;
using System.Threading.Tasks;

namespace InPort.Domain.Core
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
