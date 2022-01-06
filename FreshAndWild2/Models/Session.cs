using System;
namespace FreshAndWild2.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateSession { get; set; }
        public int NbreDeBenevoleDemandes { get; set; }
        public int NbreDeBenevole { get; set; }


    }
}
