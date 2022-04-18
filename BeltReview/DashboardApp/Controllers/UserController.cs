using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DashboardApp.Models;

namespace DashboardApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private DashboardAppContext _context;
        private bool _tableHasUsers;

        public UserController(ILogger<UserController> logger, DashboardAppContext context)
        {
            _logger = logger;
            _context = context;
            _tableHasUsers = _context.Users.FirstOrDefault() != null;
        }

        // ====================
        // ====================== Register - manage registration and admit on success
        // ====================
        [HttpPost("/Register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("RegistrationForm");
                }
                else
                {
                    user.UserLevel = _tableHasUsers ? 1 : 9; 
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.Add(user);
                    _context.SaveChanges();
                    User u = _context.Users.FirstOrDefault(us => us.Email == user.Email); 
                    
                    SetUserInSession(u);
                    return RedirectToAction("Dashboard", "Dashboard");
                }
            }
            else
            {
                return View("RegistrationForm");
            }
        }

        // ====================
        // ====================== Login route - Check credential and admit or display errors
        // ====================
        [HttpPost("/Login")]
        public IActionResult Login(LoginView formUser)
        {
            if(ModelState.IsValid)
            {
                var dbUser = _context.Users.SingleOrDefault(u => u.Email == formUser.Email);
                if(dbUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid Login");
                    ModelState.AddModelError("Password", "Invalid Login");
                    return View("LoginForm");
                }
                var Hasher = new PasswordHasher<LoginView>();
                if (Hasher.VerifyHashedPassword(formUser,dbUser.Password,formUser.Password) == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Login");
                    ModelState.AddModelError("Password", "Invalid Login");
                    return View("LoginForm");
                }
                else
                {
                    SetUserInSession(dbUser);
                    return RedirectToAction("Dashboard", "Dashboard");
                }

            }
            else
            {
                return View("LoginForm");
            }
        }

        // ====================
        // ====================== Logout - Clear Session and Redir to Homepage
        // ====================
        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        // =================================================
        // ================== Admin Routes =================
        // =================================================

        // ====================
        // ====================== New User form loader
        // ====================
        [HttpGet("/Users/New")]
        public IActionResult NewUserForm()
        {
            if (UserIsAdmin())
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedRequest","Home");
            }
        }

        // ====================
        // ====================== Edit User form loader
        // ====================
        [HttpGet("/Users/Edit/{UserId}")]
        public IActionResult EditUserForm(int UserId)
        {
            if (UserIsAdmin())
            {
                User user = _context.Users
                            .SingleOrDefault(u => u.UserId == UserId);
                return View(user);
            }
            else
            {
                return RedirectToAction("UnauthorizedRequest","Home");
            }
        }
        

        // ====================== User Management and Validation Methods
        private bool LoggedIn()
        { 
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetUserInSession(User user)
        {
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("FirstName", user.FirstName);
        }

        private bool UserIsAdmin()
        {
            if (!LoggedIn())
            {
                return false;
            }
            else
            {
                User user = _context.Users
                            .SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId") && u.UserLevel == 9);
                if(user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
