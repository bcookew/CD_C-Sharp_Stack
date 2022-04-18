using System;
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
        [HttpGet("/")]
        public IActionResult Index()
        {
            ViewBag.LoggedIn = HttpContext.Session.GetInt32("UserId") != null;
            return View();
        }

        // ====================
        // ====================== Registration form loader
        // ====================
        [HttpGet("/Register")]
        public IActionResult RegistrationForm()
        {
            return View();
        }
        

        // ====================
        // ====================== Login Form loader
        // ====================
        [HttpGet("/Login")]
        public IActionResult LoginForm()
        {
            return View();
        }

        // ====================
        // ====================== Error Catch
        // ====================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // ====================
        // ====================== Unauthorized Request to Route
        // ====================
        [HttpGet("/UnauthorizedRequest")]
        public IActionResult UnauthorizedRequest()
        {
            return View();
        }
        
        // ====================
        // ====================== Unauthorized Request to Route
        // ====================
        [Route("/{**BadRoute}")]
        public IActionResult BadRoute()
        {
            return View();
        }
        
    }
}
