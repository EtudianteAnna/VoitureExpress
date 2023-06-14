using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;


public class VoitureExpressContext : IdentityDbContext<IdentityUser>

{
    public VoitureExpressContext(DbContextOptions<VoitureExpressContext> options) : base(options) { }


    public DbSet<Voiture> ? Voiture { get; set; }
    public DbSet<ReparationVoiture> ? ReparationVoiture{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurer les tables et les relations
        // ...
    }
}

