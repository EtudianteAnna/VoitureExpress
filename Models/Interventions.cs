namespace VoitureExpress.Models
{
    public class Interventions
    {
       
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Cout { get; set; }
        public DateTime DateIntervention { get; set; }

        public int VoitureId { get; set; }
        public virtual Voiture Voitures { get; set; }

    }
}
