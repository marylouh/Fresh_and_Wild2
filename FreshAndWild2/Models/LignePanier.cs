using System;
namespace FreshAndWild2.Models
{
    public class LignePanier
    {
       
            public int Id { get; set; }                     //    Clef primaire de la ligne stockée dans la table


            public int ProduitId { get; set; }              // Clef étrangère du produit
            public Produit produit { get; set; }



            public int Quantite { get; set; }


            public int? PanierId { get; set; }            // Clef étrangère du panier
            public Panier panier { get; set; }

            public double Montant()
            {
                return Quantite * produit.Prix;
            }



        }
    }
