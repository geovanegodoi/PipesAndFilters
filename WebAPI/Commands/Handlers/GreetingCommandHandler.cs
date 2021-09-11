using Microsoft.Extensions.Logging;
using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Commands;

namespace WebAPI.Commands.Handlers
{
    public class GreetingCommandHandler : RequestHandler<GreetingCommand>
    {
        private readonly ILogger<GreetingCommandHandler> _logger;

        public GreetingCommandHandler(ILogger<GreetingCommandHandler> logger)
        {
            _logger = logger;
        }

        public override GreetingCommand Handle(GreetingCommand command)
        {
            _logger.LogInformation("{0}", command.Name);
            return base.Handle(command);
        }
    }
}
