using Paramore.Brighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Attributes;
using WebAPI.Handlers;
using WebAPI.Infrastructure;

namespace WebAPI.Queries.Handlers
{
    public class WeeklyReportQueryHandler : RequestHandler<WeeklyReportQuery>
    {
        [Logging(step: 1)]
        [Filter(step: 2, handler: typeof(ValidateHandler<>))]
        [Filter(step: 3, handler: typeof(ReadCacheHandler<>))]
        [Filter(step: 4, handler: typeof(WriteCacheHandler<>), timing: HandlerTiming.After)]
        public override WeeklyReportQuery Handle(WeeklyReportQuery command)
        {
            //_repository.ExecuteQuery(command.Query);
            return base.Handle(command);
        }
    }
}
