using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoitureExpress.Models;

namespace VoitureExpress.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        internal readonly IEnumerable<object> Interventions;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voiture>? Voiture { get; set; }
        public IEnumerable<object> Intervention { get; internal set; }
    }
}