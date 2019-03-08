using InPort.Domain;
using InPort.Domain.Core.Notifications;
using MediatR;


namespace InPort.Aplication.Core.Commands
{
    public class CommandHandler
    {
        protected readonly IUnitOfWork Uow;
        protected readonly IMediator Bus;
        //private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications)
        {
            Uow = uow;
            //_notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
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

            if (Uow.SaveChanges()) return true;

            Bus.Publish(new DomainNotification("Commit", "Tuvimos un problema al guardar tus datos."));
            return false;
        }
    }
}
