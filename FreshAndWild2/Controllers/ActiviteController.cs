using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class ActiviteController : Controller
{
    private readonly ILogger<ActiviteController> _logger;
    [Obsolete]
    private IHostingEnvironment _environment;

    [Obsolete]
    public ActiviteController(ILogger<ActiviteController> logger, IHostingEnvironment environment)
    {
        _logger = logger;

        _environment = environment;
    }

    public IActionResult Index()
    {

        return View();
    }


    public IActionResult AddActivity()
    {


        return View();
    }

    public IActionResult SePorterBenevole()
    {
        BddContext bddContext = new BddContext();
        if (HttpContext.User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Benevole");
        }
        return RedirectToAction("VeuillezVousConnecter", "Connexion");
    }




    public IActionResult Image()
    {
        return View();
    }


    public IActionResult ActivityViewUser()
    {

        List<Activite> activitesValidees = new Dal().ObtientTousLesActivite().Where(r => r.valid == true).ToList();
        return View(activitesValidees);



    }




    [HttpPost]
    [Obsolete]
    public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile")] ImageModel imageModel)
    {
       
        if (ModelState.IsValid)
        {
            //Save image to wwwroot/image
            string wwwRootPath = _environment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            imageModel.ImageName = path; 
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageModel.ImageFile.CopyToAsync(fileStream);
                imageModel.ImageName = path;
            }
            //ViewBag.Message += string.Format(path);
            //activite.image = path;
            //Insert record

            using (BddContext ctx = new BddContext())
            {
                ctx.Add(imageModel);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(AddActivity));

            }




        }
        return View(imageModel);
    }
    [HttpPost]
    public IActionResult AddActivity(Activite activite)
    {



        if (!ModelState.IsValid)
            return View(activite);


        using (Dal dal = new Dal())
        {

            dal.CreerActivite(activite);

            return RedirectToAction(nameof(ActivityViewUser));
        }


    }



    public IActionResult EditActivity()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EditActivity(int id)
    {
        if (id != 0)
        {
            using (IDal dal = new Dal())
            {
                Activite activite = dal.ObtientTousLesActivite().Where(r => r.Id == id).FirstOrDefault();
                if (activite == null)
                {
                    return View("Error");
                }
                return View();
            }
        }
        return View("Error");
    }

    [HttpPost]
    public IActionResult EditActivity(Activite activite)
    {
        

        if (activite.Id != 0)
        {
           
                BddContext bddContext = new BddContext();
                
                bddContext.Activites.Update(activite);
                bddContext.SaveChanges();
               
                return RedirectToAction("ActivityViewUser");
            
        }
        else
        {
            return View("Error");
        }
    }
    public IActionResult DeleteActivite(int id)
    {
        using (Dal dal = new Dal())
        {
            dal.SupprimerActivite(id);
        }
        return RedirectToAction("ActivityViewUser");
    }
    public IActionResult Participer(int id)
    {
        using (Dal dal = new Dal())
        {
            dal.participer(id);
        }



        return RedirectToAction("ActivityViewUser");
    }







   
}

