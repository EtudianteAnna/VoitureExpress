using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoitureExpress.Models
{
    public class Reparation
    {
        [Key]
        [Column("ReparationId")]
        public int Id { get; set; }

        public DateTime DateReparation { get; set; }

        public decimal CoutReparation { get; set; }
        public string? Reparations { get; set; }
        public string? TypeReparation { get; set; }

        [Required]

        // // Autres propriétés de la classe Reparation

        // Clé étrangère pour la voiture associée
        public int VoitureId { get; set; }
        public virtual Voiture? Voiture { get; set; }

    }
}
