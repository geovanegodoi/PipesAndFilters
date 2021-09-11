using Microsoft.Extensions.DependencyInjection;
using Paramore.Brighter;
using System;

namespace WebAPI
{
    public static partial class StartupExtensions
    {
        internal class SimpleHandlerFactory : IAmAHandlerFactory
        {
            private readonly ServiceProvider _serviceProvider;
            public SimpleHandlerFactory(IServiceCollection services)
            {
                _serviceProvider = services.BuildServiceProvider();
            }

            public IHandleRequests Create(Type handlerType)
            {
                //TODO: Create an instance of the request type
                return _serviceProvider.GetService(handlerType) as IHandleRequests;
            }

            public void Release(IHandleRequests handler)
            {

            }
        }
    }
}
