using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Data.Common;
using mvc.Models.db;
using mvc.Models.viewmodel;

namespace mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webhost;

        private IRecipeRepository _rep = new RecipeRepositoryDB();

        public AdminController(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegisterRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterRecipe(Recipe rec)
        {
            DateTime d = rec.DateAdded;
            string str = Convert.ToString(d);
            str = str.Replace(" ", "");
            str = str.Replace(":", "");

            string path = Path.Combine(this._webhost.WebRootPath, "images\\rep\\" + str);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Path.GetFileName(rec.ImageFile.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                rec.ImageFile.CopyTo(stream);
            }

            string filepath = "images/rep/" + str + "/" + fileName;
            rec.FilePath = filepath;
            
            if (rec == null)
            {
                return RedirectToAction("RegisterRecipe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _rep.Open();
                    if (_rep.InsertRecipe(rec))
                    {
                        return View("_Message", new Message("Success", "Erfolgreich hinzugefügt!"));
                    }
                    else
                    {
                        return View("_Message", new Message("Error", "Konnte nicht hinzugefügt werden"));
                    }
                }
                catch (DbException de)
                {
                    Console.WriteLine("Inner Exception " + de.ErrorCode);
                    return View("_Message", new Message("DB-Error", de.Message));
                }
                finally
                {
                    _rep.Close();
                }
            }
            return View();
        }
    }
}
