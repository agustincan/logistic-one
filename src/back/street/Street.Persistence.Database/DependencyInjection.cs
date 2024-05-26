using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Streets.Persistence.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services, string cnnString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(cnnString, action =>
                {
                    action.CommandTimeout(30);
                    //action.EnableRetryOnFailure();
                })
            );

            return services;
        }
    }
}
