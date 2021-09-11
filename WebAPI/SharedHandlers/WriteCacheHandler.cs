using Paramore.Brighter;

namespace WebAPI.SharedHandlers
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
