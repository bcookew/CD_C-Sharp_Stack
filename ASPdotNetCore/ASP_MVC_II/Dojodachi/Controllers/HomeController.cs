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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DojodachiPet pet = new DojodachiPet();
            return View(pet);
        }
        
        [HttpPost("/sleep")]
        public IActionResult sleep(string data)
        {
            Console.WriteLine("\n\ninside controller\n\n");
            dynamic pet = JsonSerializer.Deserialize<DojodachiPet>(data);
            Console.WriteLine(pet.Energy);
            // pet.Sleep();
            // Console.WriteLine(pet.Energy);
            return View("Index", pet);
        }
        [HttpGet("/feed")]
        public IActionResult feed(int hap, int full, int meals, int ener)
        {
            DojodachiPet pet = new DojodachiPet(hap,full,ener,meals);
            pet.Feed();
            return View("Index", pet);
        }
        [HttpGet("/work")]
        public IActionResult work(int hap, int full, int meals, int ener)
        {
            DojodachiPet pet = new DojodachiPet(hap,full,ener,meals);
            pet.Work();
            return View("Index", pet);
        }
        [HttpGet("/play")]
        public IActionResult play(string data)
        {
            DojodachiPet pet = JsonSerializer.Deserialize<DojodachiPet>(data);
            pet.Play();
            return View("Index", pet);
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
