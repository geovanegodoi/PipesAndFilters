using Paramore.Brighter;
using WebAPI.Attributes;
using WebAPI.Infrastructure;
using WebAPI.SharedHandlers;

namespace WebAPI.Queries.Handlers
{
    public class WeeklyReportQueryHandler : RequestHandler<WeeklyReportQuery>
    {
        private readonly IRepository _repository;

        public WeeklyReportQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        [Logging(step: 1)]
        [Filter(step: 2, handler: typeof(ValidateHandler<>))]
        [Filter(step: 3, handler: typeof(ReadCacheHandler<>))]
        [Filter(step: 4, handler: typeof(WriteCacheHandler<>), timing: HandlerTiming.After)]
        public override WeeklyReportQuery Handle(WeeklyReportQuery command)
        {
            var report = _repository.ExecuteQuery<object>(command.Query);
            return base.Handle(command);
        }
    }
}
