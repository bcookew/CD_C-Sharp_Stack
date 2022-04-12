using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginAndRegistration.Models;

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
        // ====================== Register - manage registration and admit on success
        // ====================
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return RedirectToAction("Index");
        }

        // ====================
        // ====================== Login route - Check credential and admit or display errors
        // ====================
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("Login");
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
