using Microsoft.Extensions.DependencyInjection;
using Streets.Application.Repositories;
using Streets.Application.Services;

namespace Streets.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            //services.AddScoped<IRepositoryBase, RepositoryBase>();
            services.AddScoped<IStreetRepository, StreetRepository>();

            services.AddScoped<IStreetService, StreetService>();
            return services;
        }
    }
}
