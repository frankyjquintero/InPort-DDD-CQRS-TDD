using InPort.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InPort.Aplication.Core.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
