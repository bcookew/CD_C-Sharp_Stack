using System;
using Microsoft.AspNetCore.Mvc;
namespace Portfolio_I.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("/")]
        public string Index()
        {
            return "This is my Index Route!";
        }
        
        [HttpGet("/projects")]
        public string Projects()
        {
            return "This is the Projects page!";
        }
        
        [HttpGet("/contact")]
        public string Contact()
        {
            return "This is the Contact page!";
        }
    }
}