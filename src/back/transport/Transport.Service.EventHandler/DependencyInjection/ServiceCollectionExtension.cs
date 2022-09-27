using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Transport.Service.EventHandler.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEventHandleLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
