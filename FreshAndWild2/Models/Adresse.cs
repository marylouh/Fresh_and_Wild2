using System;
using System.ComponentModel.DataAnnotations;

namespace FreshAndWild2.Models
{
    public class Adresse
    {
        public int Id { get; set; }

        //[Required]
        public int NumVoie { get; set; }

        public string Complement { get; set; }

        //[Required]
        public string LibelleVoie { get; set; }

        public string LieuDit { get; set; }
        public string ComplementAdresse { get; set; }

        //[Required]
        //[DataType(DataType.PostalCode)]
        public int CodePostal { get; set; }

        //[Required]
        public string Commune { get; set; }
    }
}
