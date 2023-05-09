using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoitureExpress.Models
{
    public class Voiture

    {
        public Voiture()
        {
            Reparations = new HashSet<Reparations>();
            Interventions = new HashSet<Interventions>();
        }
        [Key]
        [Column("VoitureId")]
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public string Finition { get; set; }
        public DateTime DateAchat { get; set; }
        public decimal Prix { get; set; }
        public string Réparations { get; set; }
        public decimal CoûtsDeRéparations { get; set; }
        public bool Disponibilité { get; set; }
        public decimal PrixDeVente { get; set; }
        public DateTime? DateDeVente { get; set; }
        public virtual ICollection<Reparations> Reparations { get; set; }
        public virtual ICollection<Interventions> Interventions { get; set; }

    }

}





