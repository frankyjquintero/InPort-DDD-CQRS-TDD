using InPort.Domain;
using InPort.Domain.Core.Notifications;
using MediatR;


namespace InPort.Aplication.Core.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _bus;
        //private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications)
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

            if (_uow.SaveChanges()) return true;

            _bus.Publish(new DomainNotification("Commit", "Tuvimos un problema al guardar tus datos."));
            return false;
        }
    }
}
