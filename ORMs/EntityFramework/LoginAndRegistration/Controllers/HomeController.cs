using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LoginAndRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
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
                    return RedirectToAction("Success");
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
                    return RedirectToAction("Success");
                }

            }
            else
            {
                return View("_Login");
            }
        }

        // ====================
        // ====================== Login/Reg Success
        // ====================
        [HttpGet("Success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetString("UserId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
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
