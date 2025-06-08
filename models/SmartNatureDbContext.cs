using Microsoft.EntityFrameworkCore;

namespace SmartNature.API.Models
{
    public class SmartNatureDbContext : DbContext
    {
        public SmartNatureDbContext(DbContextOptions<SmartNatureDbContext> options)
            : base(options) { }

        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Leitura> Leituras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>()
                .HasMany(s => s.Leituras)
                .WithOne(l => l.Sensor)
                .HasForeignKey(l => l.SensorId);
        }
    }
}
