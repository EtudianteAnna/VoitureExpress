using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;


/*public class VoitureExpressContext : IdentityDbContext<IdentityUser>

{
    public VoitureExpressContext(DbContextOptions<VoitureExpressContext> options) : base(options) { }


    public DbSet<Voiture>  Voitures { get; set; }
    public DbSet<Reparation> Reparations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configurer les tables et les relations
        // ...
        builder.Entity<Reparation>()
                .HasOne(r => r.Voiture)
                .WithMany()
                .HasForeignKey(r => r.VoitureId);
    }
}*/


//autre méthode 
public class VoitureExpressContext : IdentityDbContext<IdentityUser>
{
    public VoitureExpressContext(DbContextOptions<VoitureExpressContext> options) : base(options) { }

    public DbSet<Voiture> Voitures { get; set; }
    public DbSet<Reparation> Reparations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reparation>()
            .HasOne(r => r.Voiture)
            .WithMany(v => v.ReparationVoiture)
            .HasForeignKey(r => r.VoitureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
