using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace FreshAndWild2.Controllers
{
    public class AdminController : Controller
    {
        public bool DisplayIbvalidAccountMessage = false;
        IConfiguration configuration;
        public AdminController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Home");
            }
            return View();
        }

        //public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        //{
        //    var authSection = configuration.GetSection("Auth");
        //    string adminLogin = authSection["AdminLogin"];
        //    string adminPassword = authSection["AdminPassword"];
        //    if ((username == adminLogin) && (password == adminPassword))
        //    {

        //        var claims = new List<Claim> {
        //        new Claim(ClaimTypes.Name, username) };
        //        var claimsIdentity = new ClaimsIdentity(claims, "Login");
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //         new ClaimsPrincipal(claimsIdentity));
        //        return Redirect("/Admin/Home");

        //    }



        //    DisplayIbvalidAccountMessage = true;


        //    return View();
        //}
        //public async Task<IActionResult> OnGetLogout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return Redirect("/Admin");

        //}



        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ActiviteVUE()
        {

            List<Activite> activites = new Dal().ObtientTousLesActivite();
            return View(activites);



        }
        public IActionResult GererAdherents()
        {
            List<Adherent> adherents = new Dal().ObtenirTousLesAdherents();
            return View(adherents);
        }
        public IActionResult VAliderAdherent(int id)
        {
            using (Dal dal = new Dal())
            {
                dal.AdherentValidee(id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult GererProduits()
        {
            List<Produit> produits = new Dal().ObtenirTousLesProduits();
            return View(produits);
        }
        public IActionResult benevole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult benevole(Session session)
        {



            if (!ModelState.IsValid)
                return View(session);


            using (Dal dal = new Dal())
            {

                dal.CreerSession(session);

                return RedirectToAction(nameof(Home));
            }


        }




        public IActionResult VAliderActivite(int id)
        {
            using (Dal dal = new Dal())
            {
                dal.ActiviteValidee(id);
            }
            return RedirectToAction("Index");
        }
        //-------------------------Prouits

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
            return RedirectToAction("Home");
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
            return RedirectToAction("Home");

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
            return RedirectToAction("Home");
        }
















    }
}