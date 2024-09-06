using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Transport.Service.EventHandler.Command;

namespace Transport.Service.EventHandler
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEventHandlerLayer(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(TransportCreateHandler).Assembly);

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(TransportCreateHandler).Assembly, includeInternalTypes: true);
            //services.AddValidatorsFromAssemblyContaining<>();

            return services;
        }
    }
}
