using Microsoft.EntityFrameworkCore;
using Transport.Domain.Models;

namespace Transport.Persistence
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Transportt> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("Transport");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new TransportConfiguration(modelBuilder.Entity<Transportt>());
        }
    }
}
