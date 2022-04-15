using Aiva.Data;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/cart")]
        public IActionResult Cart()
        {
            if (base.User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }

        [HttpGet("/user")]
        public IActionResult User()
        {
            if (base.User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
    }
}
