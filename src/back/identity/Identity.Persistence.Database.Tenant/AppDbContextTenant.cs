using Common.Core.Identity.Domain;
using Common.Core.Identity.Multitenancy;
using Identity.Persistence.Database.Tenant.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.Database.Tenant
{
    public class AppDbContextTenant : DbContextIdentityTenant
    {
        public AppDbContextTenant(DbContextOptions options,
            ITenantService serviceTenant) : base(options, serviceTenant)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("Identity");
            //ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new SystemUserConfiguration(modelBuilder.Entity<ApplicationUser>());
            new SystemRoleConfiguration(modelBuilder.Entity<ApplicationRole>());
        }
    }
}
