using Paramore.Brighter;
using WebAPI.Infrastructure;

namespace WebAPI.Handlers
{
    public class WriteCacheHandler<TRequest> : RequestHandler<TRequest>
        where TRequest : class, IRequest
    {
        public override TRequest Handle(TRequest command)
        {
            //_cacheService.WriteToCache(command.Id, command);
            return base.Handle(command);
        }
    }
}
