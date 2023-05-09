
using System.ComponentModel.DataAnnotations;        
    namespace VoitureExpress.Models
{
    
    
            public class Reparation
    {
        [Key]
            public int Id { get; set; }
        public string Nom { get; set; }
            public decimal Cout { get; set; }
            public DateTime DateReparation { get; set; }

            public int VoitureId { get; set; }
            public virtual Voiture Voiture { get; set; }

        // Propriété de navigation vers la classe Interventions
        public virtual Interventions Interventions { get; set; }

    }


    }





