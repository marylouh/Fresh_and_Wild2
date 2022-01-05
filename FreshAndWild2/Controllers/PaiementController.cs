using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Mvc;


namespace FreshAndWild2.Controllers
{
    public class PaiementInfoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ModifierInfo(int id)
        {

            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    PaiementInfo paiementInfo = dal.ObtenirTousLesPaiementsInfo().Where(p => p.Id == id).FirstOrDefault();
                    if (paiementInfo == null)
                    {
                        return View("Error");
                    }
                    return View("Paiement", paiementInfo);
                }
            }
            return View("Error");
        }

        [HttpPost]

        public IActionResult ModifierInfo(PaiementInfo paiementInfo)
        {
            if (paiementInfo.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierInfo(paiementInfo.Id, paiementInfo.NumeroCb, paiementInfo.Titulaire, paiementInfo.ExpirationCb, paiementInfo.CodeCvc);
                }
                return Redirect("/Home/Index");
            }
            return View("Error");
        }

        //public int CreerInfo(int NumeroCb, string Titulaire, string ExpirationCb, int CodeCvc)
        //{
        //    PaiementInfo paiementInfo = new PaiementInfo { NumeroCb = NumeroCb, Titulaire = Titulaire, ExpirationCb = ExpirationCb, CodeCvc = CodeCvc };
        //    _bddContext.PaiementInfos.Add(paiementInfo);
        //    _bddContext.SaveChanges();
        //    return paiementInfo.Id;
        //}

        public IActionResult CreerInfo()
        {
            return View("creer");
        }

        [HttpPost]
        public IActionResult CreerInfo(PaiementInfo paiementInfo)
        {
            if (!ModelState.IsValid)
                return View(paiementInfo);

            using (Dal dal = new Dal())
            {
                dal.CreerInfo(paiementInfo);
                return RedirectToAction("/Home/Index");
            }
        }

    }

}




