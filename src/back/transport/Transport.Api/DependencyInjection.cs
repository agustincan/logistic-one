using Microsoft.Extensions.DependencyInjection;
using Transport.Api.ActionFilters;
using Transport.Api.Services;
using MediatR;
using Transport.Api.Validators;

namespace Transport.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviorApi<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior2<,>));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
            //services.AddValidatorsFromAssemblyContaining<TransportCreateCommandValidator>();

            services.AddScoped<AuthActionFilter>();

            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<ITransportServiceUow, TransportServiceUow>();
            return services;
        }
    }
}
