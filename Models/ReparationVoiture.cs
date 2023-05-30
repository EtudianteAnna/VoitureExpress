using System.ComponentModel.DataAnnotations;


namespace VoitureExpress.Models
{
    public class ReparationVoiture
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateReparation { get; set; }

        public decimal CoutReparation { get; set; }
        public string? Reparation { get; set; }
        public string TypeIntervention { get; set; }

        [Required]

        // // Autres propriétés de la classe Reparation

        // Clé étrangère pour la voiture associée
        public int VoitureId { get; set; }
        public virtual Voiture? Voiture { get; set; }

    }
}
