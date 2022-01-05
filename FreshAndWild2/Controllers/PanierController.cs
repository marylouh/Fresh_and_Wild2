using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Helpers;
using FreshAndWild2.Models;
using FreshAndWild2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreshAndWild2.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult ObtenirPanier()
        {
            var panierId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "panierId");
            Panier panier;
            if (panierId != 0)
            {
                panier = new Dal().ObtenirPanier(panierId);
            }
            else
            {
                panier = new Panier() { LignesPanier = new List<LignePanier>() };
            }
            return View(panier);
        }


        public IActionResult SuccesPaiement()
        {
            return View();
        }


        public IActionResult AjouterAuPanier(int id)
        {
            var panierId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "panierId");
            Dal dal = new Dal();

            if (panierId == 0)
            {
                panierId = dal.CreerPanier();
                dal.AjouterLigne(panierId, new LignePanier { ProduitId = id, Quantite = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "panierId", panierId);
            }
            else
            {
                Panier panier = dal.ObtenirPanier(panierId);
                int res = ProduitExisteDansPanier(panier, id);
                if (res != -1)
                {
                    dal.UpdateQuantiteLigne(res);
                }
                else
                {
                    dal.AjouterLigne(panierId, new LignePanier { ProduitId = id, Quantite = 1 });
                }
            }
            return RedirectToAction("ObtenirPanier");
        }


        public IActionResult SupprimerLigne(int id)
        {
            var panierId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "panierId");
            new Dal().SupprimerLigne(panierId, id);
            return RedirectToAction("ObtenirPanier", "Panier");
        }



        // retourne lignePanier Id si le produit existe déjà
        // retourne -1 dans le cas contraire

        private int ProduitExisteDansPanier(Panier panier, int produitId)
        {
            foreach (var lignePanier in panier.LignesPanier)
            {
                if (lignePanier.ProduitId == produitId)
                {
                    return lignePanier.Id;
                }
            }
            return -1;
        }


        //public IActionResult Payer()
        //{
        //    Dal dal = new Dal();
        //    BddContext bddContext = new BddContext();

        //    if (HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        var panierId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "panierId");
        //        Panier panier = dal.ObtenirPanier(panierId);

        //       var adherentId = User.GetLoggedInUserId<int>();
        //       Adherent adherent = bddContext.Adherents.Where(a => a.Id == adherentId).FirstOrDefault();                             

        //        PaiementViewModel PVM = new PaiementViewModel()
        //        {
        //            panier = panier,
        //            adherent = adherent,
        //        };
        //        return View();
        //    }
        //    return RedirectToAction("Index", "Produit");
        //}

        public IActionResult Payer()
        {
            Dal dal = new Dal();
            BddContext bddContext = new BddContext();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var panierId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "panierId");
                Panier panier = dal.ObtenirPanier(panierId);

                var adherentId = Convert.ToInt32(HttpContext.User.Identity.Name);
                //var adherentId = User.GetLoggedInUserId<int>();
                Adherent adherent = bddContext.Adherents.Include(p => p.paiementInfo).Include(a => a.Adresse).Where(p => p.Id == adherentId).FirstOrDefault();


                PaiementViewModel PVM = new PaiementViewModel()
                {
                    panier = panier,
                    adherent = adherent,

                };
                return View(PVM);
            }
            return RedirectToAction("VeuillezVousConnecter", "Connexion");
        }

    }
}
