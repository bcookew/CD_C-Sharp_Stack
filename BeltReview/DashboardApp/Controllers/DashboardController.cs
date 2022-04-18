using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
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
            List<User> users = _context.Users.OrderBy(u => u.UserId).ToList();
            return View("UserDashboard", users);
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