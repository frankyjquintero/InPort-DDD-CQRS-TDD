using InPort.Domain.Core;
using InPort.Domain.Core.Commands;
using InPort.Domain.Core.Notifications;
using MediatR;


namespace InPort.Aplication.Core.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _bus;
        //private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            //_notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        //protected void NotifyValidationErrors(Command message)
        //{
        //    foreach (var error in message.ValidationResult.Errors)
        //    {
        //        _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        //    }
        //}

        public bool Commit()
        {
            //if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.Publish(new DomainNotification("Commit", "Tuvimos un problema al guardar tus datos."));
            return false;
        }
    }
}
