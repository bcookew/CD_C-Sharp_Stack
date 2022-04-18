﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DashboardApp.Models;


namespace DashboardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DashboardAppContext _context;

        public HomeController(ILogger<HomeController> logger, DashboardAppContext context)
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
        public IActionResult RegistrationForm()
        {
            return View();
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
                    return View("RegistrationForm");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.Add(user);
                    _context.SaveChanges();
                    User u = _context.Users.FirstOrDefault(us => us.Email == user.Email); 
                    
                    SetUserInSession(u);
                    return RedirectToAction("Success");
                }
            }
            else
            {
                return View("RegistrationForm");
            }
        }

        // ====================
        // ====================== Login Form loader
        // ====================
        public IActionResult LoginForm()
        {
            return View();
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
                    return RedirectToAction("Success");
                }

            }
            else
            {
                return View("LoginForm");
            }
        }

        // ====================
        // ====================== Login/Reg Success
        // ====================
        [HttpGet("Success")]
        public IActionResult Success()
        {
            if(LoggedIn())
            {
                return RedirectToAction("Dashboard", "Message");
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
    }
}
