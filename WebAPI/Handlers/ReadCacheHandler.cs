using Paramore.Brighter;
using WebAPI.Infrastructure;

namespace WebAPI.Handlers
{
    public class ReadCacheHandler<TRequest> : RequestHandler<TRequest>
        where TRequest : class, IRequest
    {
        public override TRequest Handle(TRequest command)
        {
            //_cacheService.ReadFromCache(command.Id);
            return base.Handle(command);
        }
    }
}
