using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;
using System.Text.Json;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public static DojodachiPet pet = new DojodachiPet();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(pet);
        }
        
        [HttpGet("/sleep")]
        public IActionResult sleep()
        {
            pet.Sleep();
            return RedirectToAction("Index");
        }
        [HttpGet("/feed")]
        public IActionResult feed()
        {
            pet.Feed();
            return RedirectToAction("Index");
        }
        [HttpGet("/work")]
        public IActionResult work()
        {
            pet.Work();
            return RedirectToAction("Index");
        }
        [HttpGet("/play")]
        public IActionResult play()
        {
            pet.Play();
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
