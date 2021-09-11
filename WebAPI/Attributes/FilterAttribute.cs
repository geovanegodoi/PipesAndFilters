using Paramore.Brighter;
using System;

namespace WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class FilterAttribute : RequestHandlerAttribute
    {
        private Type _handler;

        public FilterAttribute(int step, Type handler, HandlerTiming timing = HandlerTiming.Before) : base(step, timing)
        {
            _handler = handler;
        }

        public override Type GetHandlerType() => _handler;
    }
}
