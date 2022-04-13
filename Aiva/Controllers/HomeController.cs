using Aiva.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Aiva.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index([FromServices] DatabaseContext context)
        {
            ViewBag.Menu = context.Items;

            return View();
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("/signup")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
