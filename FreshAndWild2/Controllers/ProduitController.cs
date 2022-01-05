using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Mvc;



namespace FreshAndWild2.Controllers
{
    public class ProduitController : Controller
    {
        // AFFICHER LA BOUTIQUE

        public IActionResult Index()
    {
        List<Produit> produits = new BddContext().Produits.ToList();
        return View(produits);
    }


    // AFFICHER UN PRODUIT

    public ActionResult DetailsProduit(int id)

    {
        Dal dal = new Dal();
        Produit produit = dal.DetailsProduit(id);
        return View(produit);
    }



    // CRUD PRODUIT

    public IActionResult CreerProduit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreerProduit(Produit produit)
    {
        BddContext bddContext = new BddContext();
        bddContext.Produits.Add(produit);
        bddContext.SaveChanges();
        return RedirectToAction("Index");
    }





    public IActionResult UpdateProduit(int id)
    {
        Produit produit = new BddContext().Produits.Find(id);
        if (produit != null)
        {
            return View(produit);
        }
        else
        {
            return View("Error");
        }
    }
    [HttpPost]
    public IActionResult UpdateProduit(Produit produit)
    {
        BddContext bddContext = new BddContext();
        bddContext.Produits.Update(produit);
        bddContext.SaveChanges();
        return RedirectToAction("Index");

    }


    public ActionResult DeleteProduit(int id)

    {
        BddContext bddContext = new BddContext();
        Produit produit = bddContext.Produits.Find(id);
        if (produit != null)
        {
            bddContext.Produits.Remove(produit);
            bddContext.SaveChanges();
        }
        return RedirectToAction("Index");
    }


    public IActionResult Panier()
    {
        return View();
    }


}
}
