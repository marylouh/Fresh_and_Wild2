using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreshAndWild2.Controllers
{
    public class AdherentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Adherent> adherents = new BddContext().Adherents.ToList();
            return View(adherents);
        }

        [HttpPost]
        public IActionResult CreerAdherent(Adherent adherent, Adresse adresse)
        {
            using (Dal ctx = new Dal())
            {
                ctx.CreerAdherent(adherent.Nom, adherent.Prenom, adresse, adherent.Telephone, adherent.Email, adherent.MotDePasseConnexion);
                RedirectToAction("CreerAdherent", new { @id = adherent.Id });
                return View("SuccesAdhesion");
            }
        }

        public IActionResult Adhesion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ModifierAdherent(int id)
        {
            if (id != 0)
            {
                using (IDal dal = new Dal())
                {
                    Adherent adherent = dal.ObtenirTousLesAdherents().FirstOrDefault(r => r.Id == id);
                    if (adherent == null)
                    {
                        return View("ErrorAdherent");
                    }
                    return View(adherent);
                }
            }
            return View("ErrorAdherent");
        }

        [HttpPost]
        public IActionResult ModifierAdherent(Adherent adherent, Adresse adresse)
        {

            if (adherent.Id != 0)
            {
                using (Dal ctx = new Dal())
                {
                    ctx.ModifierAdherent(adherent.Id, adherent.Nom, adherent.Prenom, adresse, adherent.Telephone, adherent.Email, adherent.MotDePasseConnexion);
                    return RedirectToAction("ModifierAdherent", new { @id = adherent.Id });
                }
            }
            else
            {
                return View("ErrorAdherent");
            }
        }
    }
}
