using FreshAndWild2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshAndWild2.ViewModels
{
    public class PaiementViewModel
    {
        public Adherent adherent { get; set; }
        
        public Adresse adresse { get; set; }

        public Panier panier { get; set; }

        // public virtual List<LignePanier> LignesPanier { get; set; }


    }
}
