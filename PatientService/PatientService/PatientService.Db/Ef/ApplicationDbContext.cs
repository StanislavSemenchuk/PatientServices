using Microsoft.EntityFrameworkCore;
using PatientService.Db.Entities;

namespace PatientService.Db.Ef
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Illness> Illnesses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasIndex(e => new { e.PatientId, e.IsPrimary })
                .IsUnique()
                .HasFilter($"[{nameof(Address.IsPrimary)}] = 1");
        }
    }
}
