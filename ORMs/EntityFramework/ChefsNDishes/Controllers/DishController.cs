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
    public class DishController : Controller
    {
        private readonly ILogger<DishController> _logger;
        private Context _context;

        public DishController(ILogger<DishController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("NewDish")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View();
        }
        [HttpPost("AddDish")]
        public IActionResult AddDish(Dish dish)
        {
            Console.WriteLine(dish.ChefId);
            if(dish.ChefId  == 0)
            {
                ModelState.AddModelError("ChefId", "Must select a Chef!");
                ViewBag.AllChefs = _context.Chefs.ToList();
                return View("NewDish");
            }
            if(ModelState.IsValid)
            {
                _context.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("Dishes", "Home");
            }
            else
            {
                ViewBag.AllChefs = _context.Chefs.ToList();
                return View("NewDish");
            }
        }
    }
}
