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
            if(rec.ImageFile != null) { 
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
            }
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

        public IActionResult Delete(int id)
        {
            try
            {
                _rep.Open();
                Boolean output = _rep.DeleteRecipe(id);
                if (!output)
                {
                    return View("_Message", new Message("Datenbankfehler", "Recipe could not be deleted!"));
                }
                else
                {
                    return View("_Message", new Message("Erfolgreich", "Recipe is deleted!"));
                }

            }
            catch (DbException)
            {
                return View("_Message", new Message("Datenbankfehler", "There was a problem with the database!"));
            }
            finally
            {
                _rep.Close();
            }
        }

        public IActionResult Update(Recipe newD)
        {
            try
            {
                _rep.Open();
                Boolean output = _rep.ChangeRecipe(newD.RecipeID, newD);
                if (!output)
                {
                    return View("_Message", new Message("Datenbankfehler", "Recipe could not be deleted!"));
                }
                else
                {
                    return View("_Message", new Message("Erfolgreich", "Recipe is updated!"));
                }

            }
            catch (DbException e)
            {
                return View("_Message", new Message("Datenbankfehler", e.Message));
            }
            finally
            {
                _rep.Close();
            }
        }

        public IActionResult EditRecipeDetail(int id)
        {
            try
            {
                _rep.Open();
                Recipe re = _rep.GetRecipe(id);
                return View(re);
            }
            catch (DbException)
            {
                return View("_Message", new Message("Datenbankfehler", "There was a problem with the database!"));
            }
            finally
            {
                _rep.Close();
            }
        }

        public IActionResult EditRecipe()
        {
            try
            {
                _rep.Open();
                List<Recipe> repe = _rep.GetAllRecipes();
                if (repe == null)
                {
                    return View("_Message", new Message("Datenbankfehler", "We got an Error!"));
                }
                else
                {
                    return View(repe);
                }

            }
            catch (DbException)
            {
                return View("_Message", new Message("Datenbankfehler", "We got an Error!"));
            }
            finally
            {
                _rep.Close();
            }

        }


    }
}
