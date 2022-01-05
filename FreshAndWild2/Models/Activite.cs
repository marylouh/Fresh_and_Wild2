using System;
using System.ComponentModel.DataAnnotations;

namespace FreshAndWild2.Models
{
    public class Activite
    {
        public int Id { get; set; }
        [MaxLength(30)]
        [Display(Name = "Titre")]

        //[ForeignKey("ImageId"), Column(Order = 1)]
        //public int ImageId { get; set; }
        //public ImageModel image { get; set; }
        public string titre { get; set; }
        [Display(Name = "Nombre de participants")]
        public int NbreParticipant { get; set; }

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Le lieu ne peut pas être 'null'.")]
        public string Lieu { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public string image { get; set; }
        public bool valid { get; set; }

    }
}

