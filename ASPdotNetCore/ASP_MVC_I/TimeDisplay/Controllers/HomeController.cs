using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TimeDisplay
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ViewResult Index()
        {
            DateTime ct = DateTime.Now;
            ViewBag.Date = ct.ToString("MMM dd, yyyy");
            ViewBag.Time = ct.ToString("t");
            return View();
        }
    }

}