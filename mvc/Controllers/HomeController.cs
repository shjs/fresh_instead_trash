using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using mvc.Models.db;
using mvc.Models.viewmodel;
using MySql.Data.MySqlClient;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository recipeRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult GetAllRecipes()
        {
            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                List<Recipe> r = recipeRepository.GetAllRecipes();
                return Json(r);
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }
        public IActionResult AllRecipes()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetOneRecipe(int id)
        {
            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                Recipe r = recipeRepository.GetRecipe(id);
                return Json(r);
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }
        [HttpGet]
        public IActionResult GetRecipeByOrigin(int origin)
        {
            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                List<Recipe> r = recipeRepository.GetRecipeWithOrigin(origin);
                return Json(r);
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }

        [HttpGet]
        public IActionResult GetRecipeByFilter(string vegan, string vegetarian, string regional, string sort, string searchTerm)
        {
            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                if (searchTerm == null)
                {
                    string query = QueryAssembly(vegan, vegetarian, regional);
                    query = QuerySort(sort, query);
                    List<Recipe> r = recipeRepository.GetAllRecipesSixAttribute(query);
                    return Json(r);
                }
                else
                {
                    string query = QueryAssembly(vegan, vegetarian, regional);
                    string quote = "\"";
                    searchTerm = quote + "%" + searchTerm + "%" + quote;
                    if (query == "SELECT * FROM recipes")
                    {
                        query += " WHERE recipename like " + searchTerm;
                        query = QuerySort(sort, query);
                        List<Recipe> r = recipeRepository.GetAllRecipesSixAttribute(query);
                        return Json(r);
                    }
                    else
                    {
                        query += " AND recipename like " + searchTerm;
                        query = QuerySort(sort, query);
                        List<Recipe> r = recipeRepository.GetAllRecipesSixAttribute(query);
                        return Json(r);
                    }         
                }
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }
        [HttpGet]
        public IActionResult GetRecipeSearchBox(string searchTerm)
        {
            try
            {
                string quote = "\"";
                searchTerm = quote + "%" + searchTerm + "%" + quote;
                string query = "SELECT * from recipes where recipename like ";
                query += searchTerm;
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                if (searchTerm == "")
                {
                    List<Recipe> re = recipeRepository.GetAllRecipes();
                    return Json(re);
                }
                List<Recipe> r = recipeRepository.SearchBox(query);
                return Json(r);

            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }
        [HttpGet]
        public IActionResult GetRecipeSearchCountries(string searchTerm, int value)
        {
            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                if (searchTerm == null)
                {
                    List<Recipe> re = recipeRepository.GetRecipeWithOrigin(value);
                    return Json(re);
                }
                else
                {
                    string quote = "\"";
                    searchTerm = quote + "%" + searchTerm + "%" + quote;
                    string query = "SELECT * from recipes where recipename like ";
                    query += searchTerm;
                    query += " AND origin = " + value;
                    List<Recipe> r = recipeRepository.SearchBox(query);
                    return Json(r);
                }
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }
        [HttpGet]
        public IActionResult DeleteRecipe(int id)
        {
            var user = HttpContext.Session.GetString("Admin");
            if (user == "AdminUser")
            {
                try
                {
                    recipeRepository = new RecipeRepositoryDB();
                    recipeRepository.Open();
                    recipeRepository.DeleteRecipe(id);
                    return RedirectToAction("AllRecipes", "Home");
                }
                catch (MySqlException)
                {
                    return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
                }
                catch (Exception)
                {
                    return View("Message", new Message("Fehler", "Fehler"));
                }
                finally
                {
                    recipeRepository.Close();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
            
        [HttpGet]
        public IActionResult InsertRecipe()
        {
            var user = HttpContext.Session.GetString("Admin");
            if (user == "AdminUser")
            {
                Recipe r = new Recipe();
                return View(r);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult InsertRecipe(Recipe recipe)
        {
            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                recipeRepository.InsertRecipe(recipe);
                return View("Message", new Message("Das Einfügen des Rezeptes war erfolgreich!", "Das Rezept wurde der Datenbank hinzugefügt!"));

            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler bei der Erstellung des Rezeptes"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();

        }
        [ResponseCache(Duration = 1200)]
        [HttpGet]
        public IActionResult RSSFeed()
        {
            var feed = new SyndicationFeed("neues Rezept", "Schauen Sie sich unser vor kurzem hinzugefügtes Rezept an!", new Uri("/getallrecipes"));
            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Fresh Statt Trash");
            var items = new List<SyndicationItem>();

            try
            {
                recipeRepository = new RecipeRepositoryDB();
                recipeRepository.Open();
                var recipes = recipeRepository.RSSFeed();
                foreach (var item in recipes)
                {
                    var url = Url.Action("GetAllRecipes", "Home");
                    var title = item.Recipename;
                    var ingre = item.Ingredients;
                    items.Add(new SyndicationItem(title, ingre, new Uri(url)));
                }
                feed.Items = items;

                var settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    NewLineHandling = NewLineHandling.Entitize,
                    NewLineOnAttributes = true,
                    Indent = true,
                };
                using (var stream = new MemoryStream())
                {
                    using (var xmlWriter = XmlWriter.Create(stream, settings))
                    {
                        var formatter = new Rss20FeedFormatter(feed, false);
                        formatter.WriteTo(xmlWriter);
                        xmlWriter.Flush();
                    }
                    return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
                }
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Fehler"));
            }
            finally
            {
                recipeRepository.Close();
            }
        }

        public IActionResult Countries()
        {
            return View();

        }
        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public string QueryAssembly(string vegan, string vegetarian, string regional)
        {
            string query = "SELECT * FROM recipes WHERE";
            if (vegan == "true")
            {
                query += " vegan = true";
                if (vegetarian == "true")
                {
                    query += " AND vegetarian = true";
                    if (regional == "true")
                    {
                        query += " AND regional = true";
                        return query;
                    }
                    else
                    {
                        return query;
                    }
                }
                else if (regional == "true")
                {
                    query += " AND regional = true";
                    return query;
                }
                else
                {
                    return query;
                }
            }
            else if (vegetarian == "true")
            {
                query += " vegetarian = true";
                if (regional == "true")
                {
                    query += " AND regional = true";
                    return query;
                }
                else
                {
                    return query;    
                }
            }
            else if (regional == "true")
            {
                query += " regional = true";
                return query;
            }
            else
            {
                query = "SELECT * FROM recipes";
                return query;
            }
        }
        public string QuerySort(string sort, string query)
        {
            if (sort == "Kalorien - absteigend")
            {
                return query += " ORDER BY calories desc";
            }
            else if (sort == "Kalorien - aufsteigend")
            {
                return query += " ORDER BY calories asc"; 
            }
            else if (sort == "Auswählen")
            {
                return query;
            }
            else if (sort == "Datum - neuste zuersts")
            {
                return query += "ORDER BY dateadded desc";
            }
            else
            {
                return query += "ORDER BY dateadded asc";
            }
        }
        public void CheckForm(Recipe recipe)
        {
            if (recipe.Recipename.Length > 20)
            {
                ModelState.AddModelError("Recipename", "Rezeptname darf nicht mehr als 20 Zeichen haben!");
            }
            if (recipe.DateAdded > DateTime.Now)
            {
                ModelState.AddModelError("DateAdded", "Datum darf das heutige Datum nicht überschreiten!");
            }
            if (recipe.Instructions.Length < 1)
            {
                ModelState.AddModelError("Instructions", "Es muss eine Beschreibung vorhanden sein!");
            }
            if (recipe.Ingredients.Length < 1)
            {
                ModelState.AddModelError("Ingredients", "Es müssen Zutaten vorhanden sein!");
            }
            if (recipe.Duration <= 0)
            {
                ModelState.AddModelError("Duration", "Das Rezept darf nicht weniger als bzw. 0 Minuten dauern");
            }
            if (recipe.Calories < 0)
            {
                ModelState.AddModelError("Calories", "Das Rezept darf nicht weniger als 0 Kalorien haben.");
            }
        }
    }
}
