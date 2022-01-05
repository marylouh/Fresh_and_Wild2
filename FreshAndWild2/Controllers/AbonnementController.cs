using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace FreshAndWild2.Controllers
{
    public class AbonnementController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
