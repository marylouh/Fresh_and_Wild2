using System;
namespace FreshAndWild2.Models
{
    public class Producteur
    {
       
        
            public int Id { get; set; }
            public string NomFerme { get; set; }
            public string PhotoProd { get; set; }
            public string Description { get; set; }

            //Clé étrangère
            //public int AdherentId { get; set; }
            //public Adherent adherent { get; set; }
        }
    }

