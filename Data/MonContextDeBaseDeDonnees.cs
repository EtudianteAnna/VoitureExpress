using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;

namespace VoitureExpress.Data
{
   
    
        public class MonContextDeBaseDeDonnees : DbContext
        {
            public MonContextDeBaseDeDonnees(DbContextOptions<MonContextDeBaseDeDonnees> options) : base(options)
            {
            }

            public DbSet<Voiture> Voitures { get; set; }
            public DbSet<Intervention> Interventions { get; set; }
            public DbSet<Reparation> Reparations { get; set; }
        }
    }

