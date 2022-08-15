using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Transport.Persistence;
using Transport.Service.Queries;
using System.Reflection;

namespace Transport.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddTransient<ITransportQueries, TransportQueries>();

            services.AddDbContext<AppDbContext>(options =>
               //options.UseSqlServer(
               //    Configuration.GetConnectionString("DefaultConnection"),
               //    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog")
               //)
               options.UseNpgsql(Configuration.GetConnectionString("CnnPg1")
               //opt => opt.MigrationsHistoryTable("__EFMigrationsHistory", "Transport")
               )
            );

            services.AddMediatR(Assembly.Load("Transport.Service.EventHandler"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
