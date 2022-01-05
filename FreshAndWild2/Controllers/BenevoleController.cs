using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreshAndWild2.Models;

namespace FreshAndWild2.Controllers
{
    public class BenevoleController : Controller
    {
        public IActionResult Index()
        {
            List<Session> sessions = new Dal().ObtientTousLesSession();
            return View(sessions);



        }
    }

}
