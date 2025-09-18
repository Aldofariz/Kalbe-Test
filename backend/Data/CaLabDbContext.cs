using Microsoft.EntityFrameworkCore;
using CaLabApi.Models;

namespace CaLabApi.Data
{
    public class CaLabDbContext : DbContext
    {
        public CaLabDbContext(DbContextOptions<CaLabDbContext> options) : base(options)
        {
        }

        public DbSet<McaAnalysis> McaAnalyses { get; set; }
        public DbSet<McaParameter> McaParameters { get; set; }
        public DbSet<McaSampleType> McaSampleTypes { get; set; }
        public DbSet<McaMethod> McaMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<McaAnalysis>()
                .HasOne(a => a.Method)
                .WithMany(m => m.Analyses)
                .HasForeignKey(a => a.MethodId)
                .OnDelete(DeleteBehavior.SetNull);

            
            modelBuilder.Entity<McaAnalysis>()
                .HasOne(a => a.Parameter) // gunakan navigation property
                .WithMany(p => p.Analyses)
                .HasForeignKey(a => a.ParameterId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<McaAnalysis>()
                .HasOne(a => a.SampleType) // gunakan navigation property
                .WithMany(s => s.Analyses)
                .HasForeignKey(a => a.SampleTypeId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
