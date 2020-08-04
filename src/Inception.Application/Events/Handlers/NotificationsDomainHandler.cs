using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications;
using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inception.Application.Events.Handlers
{
    public class NotificationsDomainHandler : IDomainNotificationHandler<NotificationsDomain>
    {
        private IList<NotificationsDomain> _notifications;

        public bool HasNotification { get => GetNotifications().Any(); }

        public NotificationsDomainHandler()
        {
            _notifications = new List<NotificationsDomain>();
        }

        public IList<NotificationsDomain> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(NotificationsDomain message)
        {
            _notifications.Add(message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notifications = null;
            }
        }
    }
}
