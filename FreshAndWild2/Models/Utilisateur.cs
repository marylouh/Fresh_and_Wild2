using System;
namespace FreshAndWild2.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }

        //Clé étrangère
        //public int AdresseId { get; set; }
        //public Adresse Adresse { get; set; }
    }
}
