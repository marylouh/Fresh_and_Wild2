using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FreshAndWild2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshAndWild2.Views.Activite
{
    public class AddActivity2Model : PageModel
    {
        [Obsolete]
        private IHostingEnvironment _environment;
        [Obsolete]
        public AddActivity2Model( IHostingEnvironment environment)
        {
            

            _environment = environment;
        }

        
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
                        

                    }
               



                }
            return (IActionResult)imageModel;
        }
        }
    }

