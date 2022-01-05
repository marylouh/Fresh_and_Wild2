using System;
namespace FreshAndWild2.Models
{
    public class Abonne
    {
        public int Id { get; set; }
        public int FormulePanier { get; set; }
        public double DureeAbo { get; set; }
        public DateTime DateAbo { get; set; }

        //Clé étrangère
        public int AdherentId { get; set; }
        public Adherent Adherent { get; set; }
    }
}
