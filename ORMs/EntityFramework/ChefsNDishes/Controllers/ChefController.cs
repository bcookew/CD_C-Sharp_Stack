using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class ChefController : Controller
    {
        private readonly ILogger<ChefController> _logger;
        private Context _context;

        public ChefController(ILogger<ChefController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("NewChef")]
        public IActionResult NewChef()
        {
            return View();
        }
        
        [HttpPost("AddChef")]
        public IActionResult AddChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chef);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("NewChef");
            }
        }
    }
}
