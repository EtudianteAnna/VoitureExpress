using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;



namespace VoitureExpress.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<ReparationVoiture> Reparation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReparationVoiture>().HasOne(ur => ur.Voiture)
            .WithMany(x => x.Reparations)
            .HasForeignKey(x => x.VoitureId)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}