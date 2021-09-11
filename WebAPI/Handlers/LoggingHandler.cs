using Microsoft.Extensions.Logging;
using Paramore.Brighter;
using System;

namespace WebAPI.Handlers
{
    public class LoggingHandler<TRequest> : RequestHandler<TRequest> 
        where TRequest : class, IRequest
    {
        private readonly ILogger<LoggingHandler<TRequest>> _logger;

        public LoggingHandler(ILogger<LoggingHandler<TRequest>> logger)
        {
            _logger = logger;
        }

        public override TRequest Handle(TRequest command)
        {
            _logger.LogInformation($"Generic logging {typeof(TRequest)}");
            return base.Handle(command);
        }
    }
}
