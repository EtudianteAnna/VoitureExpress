using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;
using static Humanizer.In;

namespace VoitureExpress.Data
{
   
    
        public class MonContextDeBaseDeDonnees : DbContext
        {
            public MonContextDeBaseDeDonnees(DbContextOptions<MonContextDeBaseDeDonnees> options) : base(options)
            {
            }
        // Cette classe hérite de la classe DbContext de l'espace de noms Microsoft.EntityFrameworkCore,
        // ce qui signifie qu'elle peut être utilisée pour interagir avec une base de données via Entity Framework Core.//
        //Le constructeur de la classe prend un objet DbContextOptions<MonContextDeBaseDeDonnees> en argument,
        //qui contient des options de configuration pour le contexte de base de données.//

             
            public DbSet<Voiture> Voitures { get; set; }
            public DbSet<Intervention> Interventions { get; set; }
            public DbSet<Reparation> Reparations { get; set; }
        }
    }

