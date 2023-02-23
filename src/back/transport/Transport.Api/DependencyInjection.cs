using Microsoft.Extensions.DependencyInjection;
using Transport.Api.Services;

namespace Transport.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesApi(this IServiceCollection services)
        {
            services.AddScoped<ITransportService, TransportService>();
            return services;
        }
    }
}
