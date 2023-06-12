


using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;

public class VoitureExpressContext : DbContext

{
    public VoitureExpressContext(DbContextOptions<VoitureExpressContext> options) : base(options) { }


    public DbSet<Voiture>? Voiture { get; set; }
    public DbSet<ReparationVoiture>? ReparationVoiture { get; set; }
} 





