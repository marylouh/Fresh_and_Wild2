using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FreshAndWild2.Controllers
{
    public class ConnexionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Adherent> adherents = new BddContext().Adherents.ToList();
            return View(adherents);
        }

        public IActionResult Connexion()
        {
            return View();
        }

        public IActionResult ErrorConnexion()
        {
            return View();
        }

        public IActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult VeuillezVousConnecter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConnexionAdherent(Adherent adherent)
        {
            if (!ModelState.IsValid)
            {
                return View("ErrorConnexion");
            }
            using (IDal dal = new Dal())
            {
                Adherent adherentAdh = dal.ObtenirTousLesAdherents().Where(e => e.AJour == true && e.Email == adherent.Email && e.MotDePasseConnexion == adherent.MotDePasseConnexion).FirstOrDefault();
                if (adherentAdh != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, adherentAdh.Id.ToString()),
                    };
                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);
                    return StatusCode(200);
                }
                return StatusCode(501);
            }
        }
    }
}
