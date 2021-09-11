using Microsoft.Extensions.DependencyInjection;
using Paramore.Brighter;
using System.Linq;
using WebAPI.Commands;
using WebAPI.Commands.Handlers;
using WebAPI.Queries;
using WebAPI.Queries.Handlers;

namespace WebAPI
{
    public static partial class StartupExtensions
    {
        public static void AddCommandsAndHandlers(this IServiceCollection services)
        {
            var registry = CreateSubscriberRegistry();
            services.RegisterHandlersIntoDIContainer();
            services.RegisterCommandProcessor(registry);            
        }

        private static SubscriberRegistry CreateSubscriberRegistry()
        {
            var registry = new SubscriberRegistry();

            registry.Register<GreetingCommand  , GreetingCommandHandler>();
            registry.Register<PlaceOrderCommand, PlaceOrderCommandHandler>();
            registry.Register<WeeklyReportQuery, WeeklyReportQueryHandler>();

            return registry;
        }

        private static void RegisterHandlersIntoDIContainer(this IServiceCollection services)
            => typeof(Startup)
            .Assembly
            .ExportedTypes
            .Where(t => typeof(IHandleRequests).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .ToList()
            .ForEach(handler => services.AddSingleton(handler));

        private static void RegisterCommandProcessor(this IServiceCollection services, SubscriberRegistry registry)
        {
            var builder = CommandProcessorBuilder.With()
                .Handlers(new HandlerConfiguration(
                    subscriberRegistry: registry,
                    handlerFactory: new SimpleHandlerFactory(services)
                ))
                .DefaultPolicy()
                .NoTaskQueues()
                .RequestContextFactory(new InMemoryRequestContextFactory());

            services.AddSingleton(builder.Build());
        }
    }
}
