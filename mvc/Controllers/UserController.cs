
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
using mvc.Models.db.sql;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            Login l = new Login();
            return View(l);
        }
        [HttpPost]
        public IActionResult LoginAdmin(Login user)
        {
            if (user == null)
            {
                return View(user);
            }
            try
            {
                userRepository = new UserRepositoryDB();
                userRepository.Open();
                User LoggedInUser = userRepository.Authenticate(user.UsernameOrEMail, user.Password);
                if (LoggedInUser.IsAdmin == true)
                {
                    HttpContext.Session.SetString("Admin", "AdminUser");
                    return RedirectToAction("AllRecipes", "Home");
                }
                else
                {
                    ModelState.AddModelError("UsernameOrEMail", "Benutzername/Email oder Passwort stimmen nicht!");
                    return View(user);
                }
            }
            catch (MySqlException)
            {
                return View("Message", new Message("Datenbankfehler", "Fehler mit der Datenbank"));
            }
            catch (Exception)
            {
                return View("Message", new Message("Fehler", "Ein Fehler ist aufgetreten"));
            }
            finally
            {
                userRepository.Close();
            }
        }
        public IActionResult GetAllUsers()
        {
            try
            {
                userRepository = new UserRepositoryDB();
                userRepository.Open();
                List<User> r = userRepository.GetAllUsers();
                return Json(r);
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
                userRepository.Close();
            }
        }
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                userRepository = new UserRepositoryDB();
                userRepository.Open();
                userRepository.DeleteUser(id);
                return RedirectToAction("AllRecipes", "Home");
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
                userRepository.Close();
            }
        }
        public IActionResult AdminArea()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
