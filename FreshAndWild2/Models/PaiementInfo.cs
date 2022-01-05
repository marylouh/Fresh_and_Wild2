using System;
namespace FreshAndWild2.Models
{
    public class PaiementInfo
    {
        public int Id { get; set; }


        //[MaxLength(16)]
        public int NumeroCb { get; set; }

        //[MaxLength(30)]
        public string Titulaire { get; set; }

        public string ExpirationCb { get; set; }

        //[MaxLength(4)]
        public int CodeCvc { get; set; }

    }
}
