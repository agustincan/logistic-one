using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Transport.Repository.Repos;

namespace Transport.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<ITransportRepository, TransportRepository>();
            return services;
        }
    }
}
