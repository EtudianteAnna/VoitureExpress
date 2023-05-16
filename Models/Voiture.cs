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
        public string? Finition { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAchat { get; set; }
        public decimal Prix { get; set; }
        public string? Réparations { get; set; }
        public decimal CoûtsDeRéparations { get; set; }
        public bool Disponibilité { get; set; }
        public decimal PrixDeVente { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDeVente { get; set; }
        
        public virtual ICollection<Interventions>? Interventions { get; set; }

    }

}





