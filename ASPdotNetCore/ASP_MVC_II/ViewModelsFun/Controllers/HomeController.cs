using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ViewModelsFun.Models;

namespace ViewModelsFun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/names")]
        public IActionResult Names()
        {
            string[] names = new string[]
            {
                "Rob",
                "Nora",
                "Felder",
                "John",
                "Ben"
            };
            return View(names);
        }
        [HttpGet("/users")]
        public IActionResult Users()
        {
            List<User> users = new List<User>()
            {
                new User("Rob","Williams"),
                new User("Nora","Williams"),
                new User("Felder","Williams"),
                new User("John","Williams"),
                new User("Ben","Williams")
            };
            return View(users);
        }
        [HttpGet("/user")]
        public IActionResult UserView()
        {
            User Ben = new User("Ben","Williams");
            return View(Ben);
        }
        [HttpGet("/numbers")]
        public IActionResult numbers()
        {
            int[] numbers = new int[]
            {
                1,
                2,
                3,
                4,
                5
            };
            return View(numbers);
        }
        [HttpGet("/message")]
        public IActionResult Message()
        {
            string[] msg = {"Lorem ipsum dolor...and so on and so forth..."};
            return View(msg);
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
    public class User
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}

        public User (string f, string l)
        {
            FirstName = f;
            LastName = l;
        }
    }


}
