using Microsoft.EntityFrameworkCore;
using lampen.Models;

namespace lampen.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Lamp> Lamps => Set<Lamp>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<Style> Styles => Set<Style>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedAppData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}