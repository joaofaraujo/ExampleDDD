using Inception.CrossCutting.EventsDomain.Entities;
using Inception.CrossCutting.EventsDomain.Interfaces;
using System.Collections.Generic;

namespace Inception.CrossCutting.EventsDomain.Notificacoes.Notifications.Handlers
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : EventDomain
    {
        bool HasNotification { get; }
        IList<T> GetNotifications();
    }
}
