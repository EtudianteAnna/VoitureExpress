
using System.ComponentModel.DataAnnotations;
    namespace VoitureExpress.Models
{
    public abstract class Intervention
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Cout { get; set; }
        public DateTime DateIntervention { get; set; }

        public int VoitureId { get; set; }
        public virtual Voiture Voiture { get; set; }
    }

    public class Reparations : Intervention
    {
        public DateTime DateReparation { get; set; }
    }

    public class Interventions : Intervention
    {
        // Propriété spécifique à la classe Interventions
        public new DateTime DateIntervention { get; set; }

        // Propriété de navigation vers la classe Reparations
        public virtual Reparations Reparations { get; set; }
    }
}

