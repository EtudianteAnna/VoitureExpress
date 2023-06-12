using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace VoitureExpress.Models
{
    public class Voiture
    {
        [Key]
        [Column("VoitureId")]
        public int Id { get; set; }

        public string? Marque { get; set; }
        public string? Modele { get; set; }
        public int Annee { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }
        public string? Finition { get; set; }
        public Decimal PrixDeVente { get; set; }
        public string? Disponibilite { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeVente { get; set; }

        // Propriété de navigation vers les réparations
        public virtual ICollection<ReparationVoiture> ReparationVoiture { get; set; }
        public void LoadReparation(IdentityDbContext context)
        {
            ReparationVoiture = context.Set<ReparationVoiture>()
                .Where(r => r.VoitureId == Id)
               .ToList();
        }
        }
  
 
}