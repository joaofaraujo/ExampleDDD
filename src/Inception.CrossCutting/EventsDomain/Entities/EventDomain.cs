using Inception.CrossCutting.EventsDomain.Interfaces;
using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications.Handlers;

namespace Inception.CrossCutting.EventsDomain.Entities
{
    public class EventDomain
    {
        public static IContainer Container { get; set; }

        public string EventType { get; protected set; }

        protected EventDomain()
        {
            EventType = GetType().Name;
        }

        public static void RaiseEvent<T>(T theEvent) where T : Event
        {
            if (Container == null)
            {
                return;
            }

            var obj = Container.GetService(theEvent.EventType.Equals("NotificacoesDominio") ? typeof(IDomainNotificationHandler<T>) : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(theEvent);
        }
    }
}
