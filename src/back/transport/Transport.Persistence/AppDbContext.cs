using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Transport.Domain.Models;

namespace Transport.Persistence
{ 
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
         
        }

        public AppDbContext()
        {

        }

        public DbSet<Transportt> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("Transport");
            ModelConfig(modelBuilder);
        }

        public string GetTableName<T>()
        {
            return ((TableAttribute)typeof(T).GetCustomAttribute(typeof(TableAttribute))).Name;
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new TransportConfiguration(modelBuilder.Entity<Transportt>());
        }
    }
}
