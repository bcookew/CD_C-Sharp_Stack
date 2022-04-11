using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        // ================================
        // ================================== Home Route
        // ================================
        public IActionResult Index()
        {
            ViewBag.AllDishes = _context.Dishes.ToList();
            return View();
        }

        // ================================
        // ================================== Load new dish form
        // ================================
        [HttpGet("DishForm")]
        public IActionResult NewDish()
        {
            return View();
        }

        // ================================
        // ================================== Save new dish to DB
        // ================================
        [HttpPost("AddNew")]
        public IActionResult AddNew(Dish dish)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish");
            }
        }

        // ================================
        // ================================== Display Dish details by ID
        // ================================
        [HttpGet("dish/{id}")]
        public IActionResult ViewDish(int id)
        {
            Dish QueriedDish = _context.Dishes
                .SingleOrDefault(dish => dish.DishId == id);
            return View("Dish", QueriedDish);
        }

        // ================================
        // ================================== Edit Dish by Id
        // ================================
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            Dish QueriedDish = _context.Dishes
                .SingleOrDefault(dish => dish.DishId == id);
            return View("EditDish", QueriedDish);
        }

        // ================================
        // ================================== Update DB info
        // ================================
        [HttpPost("update")]
        public IActionResult Update(Dish dish)
        {
            // Pull DB Copy
            Dish QueriedDish = _context.Dishes
                .SingleOrDefault(d => d.DishId == dish.DishId);
            // Update Values
            QueriedDish.Name = dish.Name;
            QueriedDish.Chef = dish.Chef;
            QueriedDish.Description = dish.Description;
            QueriedDish.Calories = dish.Calories;
            QueriedDish.Tastiness = dish.Tastiness;
            QueriedDish.UpdatedAt = DateTime.Now;
            // Save back to DB
            _context.SaveChanges();
            // Redirect to homepage
            return View("Dish", dish);
        }

        // ================================
        // ================================== Remove a dish by ID
        // ================================
        
        [HttpGet("delete/{id}")]
        public IActionResult RemoveDish(int id)
        {
            Dish QueriedDish = _context.Dishes
                .SingleOrDefault(dish => dish.DishId == id);
            _context.Dishes.Remove(QueriedDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
