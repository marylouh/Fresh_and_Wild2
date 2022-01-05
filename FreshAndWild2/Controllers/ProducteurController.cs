using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Mvc;


namespace FreshAndWild2.Controllers
{
    public class ProducteurController : Controller
    {
        public IActionResult Index()
        {
            List<Producteur> producteurs = new Dal().ObtenirTousLesProducteurs();
            return View(producteurs);
        }
    }
}
