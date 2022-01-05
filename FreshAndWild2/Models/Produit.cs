using System;
namespace FreshAndWild2.Models
{
    public class Produit
    {
        
        public int Id { get; set; }
        public string Nom { get; set; }

        public int ProducteurId { get; set; }
        public Producteur Producteur { get; set; }


        public string Description { get; set; }
        public string Conditionnement { get; set; }
        public double Prix { get; set; }
        public string Photo { get; set; }
        public int Stock { get; set; }

    
}
}
