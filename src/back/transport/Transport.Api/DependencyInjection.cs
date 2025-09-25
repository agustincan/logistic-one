using Microsoft.Extensions.DependencyInjection;
using Transport.Api.ActionFilters;
using Transport.Api.Services;
using MediatR;
using Transport.Api.Validators;
using System.Reflection;
using FluentValidation;

namespace Transport.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviorApi<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
            services.AddScoped<AuthActionFilter>();

            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<ITransportServiceUow, TransportServiceUow>();
            services.AddScoped<ICompanyServiceUow, CompanyServiceUow>();
            return services;
        }
    }
}
