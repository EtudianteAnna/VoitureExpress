namespace VoitureExpress.Models
{
    
    
            public class Reparations
        {
            
            public int Id { get; set; }
            public string Nom { get; set; }
            public decimal Cout { get; set; }
            public DateTime DateReparation { get; set; }

            public int VoitureId { get; set; }
            public virtual Voiture Voiture { get; set; }
        }


    }





