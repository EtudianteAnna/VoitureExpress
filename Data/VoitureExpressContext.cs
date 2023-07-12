using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using VoitureExpress.Models;

public class VoitureExpressContext : IdentityDbContext<IdentityUser>
{
    public VoitureExpressContext(DbContextOptions<VoitureExpressContext> options) : base(options) { }

    public DbSet<Voiture>? Voitures { get; set; }
    public DbSet<Reparation>? Reparations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reparation>()
            .HasOne(r => r.Voiture)
            .WithMany(v => v.ReparationVoiture)
            .HasForeignKey(r => r.VoitureId)
            .OnDelete(DeleteBehavior.Cascade);
        base.OnModelCreating(modelBuilder);
    }
 
}


