﻿using System;
namespace FreshAndWild2.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateSession { get; set; }
        public int NbreDeBenevolesDemandes { get; set; }
        public int NbreDeBenevoles { get; set; }


    }
}
