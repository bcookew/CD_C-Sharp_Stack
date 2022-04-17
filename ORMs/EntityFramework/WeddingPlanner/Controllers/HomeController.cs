using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WeddingPlannerContext _context;

        public HomeController(ILogger<HomeController> logger, WeddingPlannerContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ====================
        // ====================== Home Route - Display Homepage
        // ====================
        public IActionResult Index()
        {
            return View();
        }

        // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        // xxxxxxxxxxxxxxxxxxx  User Routes  xxxxxxxxxxxxxxxxxxx
        // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        // ====================
        // ====================== Registration form loader
        // ====================
        [HttpGet("RegistrationForm")]
        public IActionResult RegistrationForm()
        {
            return PartialView("_Register");
        }
        // ====================
        // ====================== Register - manage registration and admit on success
        // ====================
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("_Register");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.Add(user);
                    _context.SaveChanges();
                    User u = _context.Users.FirstOrDefault(us => us.Email == user.Email); 
                    HttpContext.Session.SetInt32("UserId", u.UserId);
                    HttpContext.Session.SetString("FirstName", u.FirstName);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("_Register");
            }
        }

        // ====================
        // ====================== Login Form loader
        // ====================
        [HttpGet("LoginForm")]
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        // ====================
        // ====================== Login route - Check credential and admit or display errors
        // ====================
        [HttpPost("Login")]
        public IActionResult Login(LoginView formUser)
        {
            if(ModelState.IsValid)
            {
                var dbUser = _context.Users.SingleOrDefault(u => u.Email == formUser.Email);
                if(dbUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid Login");
                    ModelState.AddModelError("Password", "Invalid Login");
                    return View("_Login");
                }
                var Hasher = new PasswordHasher<LoginView>();
                if (Hasher.VerifyHashedPassword(formUser,dbUser.Password,formUser.Password) == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Login");
                    ModelState.AddModelError("Password", "Invalid Login");
                    return View("_Login");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                    HttpContext.Session.SetString("FirstName", dbUser.FirstName);
                    return RedirectToAction("Dashboard");
                }

            }
            else
            {
                return View("_Login");
            }
        }

        // ====================
        // ====================== Logout - Clear Session and Redir to Homepage
        // ====================
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        // xxxxxxxxxxxxxxxx  Planner Routes  xxxxxxxxxxxxxxxxxxx
        // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        // ====================
        // ====================== Planner Dashboard
        // ====================

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserId") != null)
            {
                List<Wedding> Weddings = _context.Weddings
                                        .Include(w => w.Creator)
                                        .Include(w => w.GuestsAttending)
                                            .ThenInclude(ga => ga.User)
                                        .ToList();
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                return View(Weddings);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // ====================
        // ====================== New Wedding Form loader
        // ====================
        [HttpGet("NewWeddingForm")]
        public IActionResult NewWedding()
        {
            return PartialView("_NewWedding");
        }

        // ====================
        // ====================== Add Wedding to DB
        // ====================
        [HttpPost("AddWedding")]
        public IActionResult AddWedding(Wedding wedding)
        {
            if(ModelState.IsValid)
            {
                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("_NewWedding");
            }
        }

        // ====================
        // ====================== View Wedding
        // ====================
        [HttpGet("ViewWedding/{id}")]
        public IActionResult ViewWedding(int id)
        {
            Wedding wedding =  _context.Weddings
                                .Include(w => w.Creator)
                                .Include(w => w.GuestsAttending)
                                    .ThenInclude(ga => ga.User)
                                .SingleOrDefault(w => w.WeddingId == id);
            return View(wedding);
        }

        // ====================
        // ====================== Delete Wedding
        // ====================
        public IActionResult RemoveWedding(int id)
        {
            if(HttpContext.Session.GetInt32("UserId") != null) // Ensures User in Session
            {
                Wedding wedding = _context.Weddings
                                        .SingleOrDefault(w => w.WeddingId == id);
                int? UserId = HttpContext.Session.GetInt32("UserId");
                if(wedding.UserId == UserId) // Ensures User in Session is event Owner
                {
                    _context.Remove(wedding);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // ====================
        // ====================== Error Catch
        // ====================

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
