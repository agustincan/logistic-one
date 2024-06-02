using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Transport.Persistence;
using Transport.Repository.Abstractions;
using Transport.Repository.Repos;
using Transport.Repository.UowGeneric;

namespace Transport.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<IUnitOfWorkGeneric<AppDbContext>, UnitOfWorkGeneric<AppDbContext>>();

            services.TryAddScoped<ITransportRepository, TransportRepository>();
            services.TryAddScoped<ITransportRepositoryUow, TransportRepositoryUow>();

            return services;
        }
    }
}
