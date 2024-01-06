using Microsoft.EntityFrameworkCore;
using Streets.Persistence.Database.Configuration;
using Streets.Persistence.Database.Models;

namespace Streets.Persistence.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("Transport");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new StreetConfiguration(modelBuilder.Entity<Street>());
        }

        public DbSet<Street> Streets { get; set; }
    }
}