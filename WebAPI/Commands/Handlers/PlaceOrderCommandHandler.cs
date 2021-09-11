using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Attributes;
using WebAPI.Commands;
using WebAPI.Handlers;

namespace WebAPI.Commands.Handlers
{

    public class PlaceOrderCommandHandler : RequestHandler<PlaceOrderCommand>
    {
        [Logging(step: 1)]
        [Filter(step: 2, handler: typeof(RetryHandler<>))]
        [Filter(step: 3, handler: typeof(ValidateHandler<>))]
        public override PlaceOrderCommand Handle(PlaceOrderCommand command)
        {
            return base.Handle(command);
        }
    }

    public class RetryHandler<TRequest> : RequestHandler<PlaceOrderCommand>
    {
        public override PlaceOrderCommand Handle(PlaceOrderCommand command)
        {
            try
            {
                return base.Handle(command);
            }
            catch (Exception)
            {
                return base.Handle(command);
            }
        }
    }


}
