using System.Reflection;
using Localidad.Models;
using Microsoft.EntityFrameworkCore;

namespace Localidad
{
    public class LDbContext : DbContext
    {
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Depto> Depto { get; set; }
        public LDbContext(DbContextOptions<LDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}