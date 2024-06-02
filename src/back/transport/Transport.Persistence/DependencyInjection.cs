using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Transport.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection")
              //x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Transport")
              ));

            return services;
        }
    }
}
