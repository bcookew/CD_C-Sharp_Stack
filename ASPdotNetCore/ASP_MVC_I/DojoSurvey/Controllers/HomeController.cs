using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(string name, string campus, string lang, string comment)
        {
            ViewBag.name = name;
            ViewBag.campus = campus;
            ViewBag.lang = lang;
            ViewBag.comment = comment;
            return View();
        }
    }
}