using Inception.CrossCutting.EventsDomain.Entities;
using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications;
using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inception.Web.Controllers.Base
{
    public class BaseController<T> : Controller where T : class
    {
        private readonly ILogger<T> _logger;

        protected BaseController(ILogger<T> logger)
        {
            this._logger = logger;
        }

        protected IDomainNotificationHandler<NotificationsDomain> Notifications { get; } = EventDomain.Container.GetService<IDomainNotificationHandler<NotificationsDomain>>();

        protected void GetNotificationsDomain()
        {
            if (Notifications.HasNotification)
            {
                foreach (var item in Notifications.GetNotifications())
                {
                    if (item.Erro)
                        _logger.LogError(item.Valor);
                    else
                        _logger.LogWarning(item.Valor);
                }
            }
        }
    }
}
