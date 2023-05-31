using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime DateAchat { get; set; }
        public string? Finition { get; set; }
        public Decimal PrixDeVente { get; set; }
        public string? Disponibilite { get; set; }
        public DateTime DateDeVente { get; set; }
        // Autres propriétés de la classe Voiture

        // Propriété de navigation vers les réparations
        public virtual ICollection<ReparationVoiture>? Reparations { get; set; }
    }


}