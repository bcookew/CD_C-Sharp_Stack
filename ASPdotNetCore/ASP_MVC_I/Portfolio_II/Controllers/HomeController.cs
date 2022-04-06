using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Portfolio_II
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet("/projects")]
        public ViewResult Projects()
        {
            return View();
        }
        [HttpGet("/contact")]
        public ViewResult Contact()
        {
            return View();
        }
    }
}