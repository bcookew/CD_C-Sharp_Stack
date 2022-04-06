using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers
{
    public class FunController : Controller
    {
        [HttpGet("/")]
        public ViewResult Index()
        {
            return View();
        }
    }
}