using Paramore.Brighter;
using System;

namespace WebAPI.Handlers
{
    public class ValidateHandler<TRequest> : RequestHandler<TRequest>
        where TRequest : class, IRequest
    {
        public override TRequest Handle(TRequest command)
        {
            if (command.Id == Guid.Empty)
                throw new InvalidOperationException(message: "Invalid Order Id");

            return base.Handle(command);
        }
    }


}
