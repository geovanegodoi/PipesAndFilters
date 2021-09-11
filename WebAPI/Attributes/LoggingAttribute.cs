using Paramore.Brighter;
using System;
using WebAPI.Handlers;

namespace WebAPI.Attributes
{
    public class LoggingAttribute : RequestHandlerAttribute
    {
        public LoggingAttribute(int step, HandlerTiming timing = HandlerTiming.Before) : base(step, timing)
        {

        }

        public override Type GetHandlerType() => typeof(LoggingHandler<>);
    }
}
