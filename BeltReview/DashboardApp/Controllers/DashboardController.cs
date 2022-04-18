using System;
using System.Collections.Generic;
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
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private DashboardAppContext _context;

        public DashboardController(ILogger<DashboardController> logger, DashboardAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ====================
        // ====================== Register - manage registration and admit on success
        // ====================
        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
            if(!LoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            List<User> users = _context.Users.OrderBy(u => u.UserId).ToList();
            return View("UserDashboard", users);
        }

        // ====================
        // ====================== User Profiles
        // ====================

        [HttpGet("/Users/Show/{id}")]
        public IActionResult Profile(int id)
        {
            if(!LoggedIn())
            {
                RedirectToAction("Index","Home");
            }
            Profile profile = new Profile();
            profile.User = _context.Users
                            .Include(u => u.MessagesRecieved)
                                .ThenInclude(mr => mr.Author)
                            .Include(u => u.MessagesRecieved)
                                .ThenInclude(mr => mr.CommentsOnMessage)
                            .SingleOrDefault(u => u.UserId == id);
            profile.Message = new Message();
            profile.Comment = new Comment();
            return View();
        }
        

        // ====================== User Management and Validation Methods
        private void SetUserInSession(User user)
        {
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("FirstName", user.FirstName);
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