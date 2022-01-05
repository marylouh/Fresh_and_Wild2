using System;
using System.Collections.Generic;

namespace FreshAndWild2.Models
{
    public class Panier
    {
        
        public int Id { get; set; }

        public virtual List<LignePanier> LignesPanier { get; set; }

    
}
}
