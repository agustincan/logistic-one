using Common.Core.Domain;
using Identity.Persistence.Database.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options
        )
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            //builder.HasDefaultSchema("Identity");

            // Model Contraints
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new SystemUserConfiguration(modelBuilder.Entity<ApplicationUser>());
            new SystemRoleConfiguration(modelBuilder.Entity<ApplicationRole>());
        }

        //public DbSet<SystemUser> SystemUsers { get; set; }
        //public DbSet<SystemRole> SystemRoles { get; set; }
    }
}