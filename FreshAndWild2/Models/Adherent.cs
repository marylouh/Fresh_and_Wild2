using System;
using System.ComponentModel.DataAnnotations;

namespace FreshAndWild2.Models
{
    public class Adherent
    {
        public int Id { get; set; }

        //Clé étrangère
        public int? AdresseId { get; set; }
        public Adresse Adresse { get; set; }
        public int? PaiementInfoId { get; set; }
        public PaiementInfo paiementInfo { get; set; }

        public Boolean Admin { get; set; }

        //[Required]
        //[MaxLength(28)]
        //[DataType(DataType.Text)]
        //[RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Veuillez entrer un nom.")]
        public string Nom { get; set; }

        //[Required]
        //[MaxLength(28)]
        //[DataType(DataType.Text)]
        //[RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Veuillez entrer un prénom.")]
        public string Prenom { get; set; }

        //public Adresse Adresse { get; set; }

        //[Required]
        //[MinLength(10)]
        //[MaxLength(12)]
        //[DataType(DataType.Text)]
        //[RegularExpression("^([+]?33[-]?|[0])?[1-9][0-9]{8}$", ErrorMessage = "Veuillez entrer un téléphone.")]
        public string Telephone { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression("(?<user>[^@]+)@(?<host>.+)", ErrorMessage = "Veuillez entrer un email.")]
        public string Email { get; set; }

        //[Required]
        //[MinLength(8)]
        //[DataType(DataType.Password)]
        //[RegularExpression("(?=.*d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Veuillez entrer un mot de passe.")]
        public string MotDePasseConnexion { get; set; }


        public DateTime DateAdhesion { get; set; }
        public bool AJour { get; set; }
        
    }
}
