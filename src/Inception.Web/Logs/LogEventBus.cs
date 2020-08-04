using EventBus.Domain;
using Microsoft.Extensions.Logging;
using System;

namespace Inception.Web.Logs
{
    public class LogEventBus : ILogEventBus
    {
        private readonly ILogger<LogEventBus> _logger;

        public LogEventBus(ILogger<LogEventBus> logger)
        {
            this._logger = logger;
        }

        public void Error(string message, Exception exception = null)
        {
            if (exception != null)
                _logger.LogError(exception, message);
            else
                _logger.LogError(message);
        }

        public void Information(string message, Exception exception = null)
        {
            if (exception != null)
                _logger.LogInformation(exception, message);
            else
                _logger.LogInformation(message);
        }

        public void Warning(string message, Exception exception = null)
        {
            if (exception != null)
                _logger.LogWarning(exception, message);
            else
                _logger.LogWarning(message);
        }
    }
}
