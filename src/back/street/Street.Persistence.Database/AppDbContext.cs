using Microsoft.EntityFrameworkCore;
using Streets.Persistence.Database.Configuration;
using Streets.Persistence.Database.Models;
using Streets.Persistence.Database.Seeds;

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
            //ModelSeed(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new StreetConfiguration(modelBuilder.Entity<Street>());
        }

        private void ModelSeed(ModelBuilder modelBuilder)
        {
            new StreetSeed(modelBuilder.Entity<Street>());
        }

        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<StreetCopy> StreetCopies { get; set; }
    }
}