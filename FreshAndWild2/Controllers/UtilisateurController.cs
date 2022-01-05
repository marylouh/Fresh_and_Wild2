using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreshAndWild2.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public UtilisateurController()
        {
        }

        public IActionResult ModifierUtilisateur(int id)
        {
            if (id != 0)
            {
                using (IDal dal = new Dal())
                {
                    Adherent adherent = dal.ObtenirTousLesAdherents().FirstOrDefault(r => r.Id == id);
                    if (adherent == null)
                    {
                        return View("Error");
                    }
                    return View(adherent);
                }
            }
            return View("Error");
        }
    }
}
