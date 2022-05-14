using Aiva.Data;
using Aiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aiva.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private DatabaseContext db;

        public HomeController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("/")]
        public IActionResult Index([FromServices] DatabaseContext context)
        {
            ViewBag.IsAuthorized = base.User.Identity.IsAuthenticated;

            if (base.User.Identity.IsAuthenticated)
            {
                var login = base.User.Identity.Name;
                var items = db.CartItems.Include(x => x.Item).Include(x => x.Client).Include(x => x.Item.Kitchen).Where(x => x.Client.Login == login).ToList();
                if (items.Any())
                {
                    var selectedKitchen = items[0].Item.Kitchen;
                    ViewBag.Menu = context.Items.Include(x => x.Kitchen).ToList().Where(x => x.Kitchen.Id == selectedKitchen.Id).GroupBy(x => x.Kitchen).ToList();
                }
                else
                {
                    // корзине пусто
                    ViewBag.Menu = context.Items.Include(x => x.Kitchen).ToList().GroupBy(x => x.Kitchen).ToList();
                }
            }
            else
            {
                ViewBag.Menu = context.Items.Include(x => x.Kitchen).ToList().GroupBy(x => x.Kitchen).ToList();
            }

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
            ViewBag.Kitchens = db.Kitchen.ToList();
            return View();
        }

        [HttpGet("/cart")]
        public IActionResult Cart()
        {
            if (base.User.Identity.IsAuthenticated)
            {
                var login = base.User.Identity.Name;
                var items = db.CartItems.Include(x => x.Item).Include(x => x.Client).Where(x => x.Client.Login == login).ToList();
                if (!items.Any())
                {
                    ViewBag.IsEmpty = true;
                }
                else
                {
                    ViewBag.IsEmpty = false;
                }
                ViewBag.Cart = items;
                return View();
            }
            else
                return RedirectToAction("Login", "Home");
        }

        [HttpGet("/user")]
        public IActionResult User()
        {
            ViewBag.HasOrders = true;
            if (base.User.Identity.IsAuthenticated)
            {
                var login = base.User.Identity.Name;

                var user = db.Clients.FirstOrDefault(x => x.Login == login);
                var cook = db.Cooks.Include(x => x.Kitchen).FirstOrDefault(x => x.Login == login);

                if (user is null && cook is null)
                    return RedirectToAction("Index", "Home");

                if (user is not null)
                {
                    var orders = db.OrderItems
                        .Where(x => x.Order.Client.Id == user.Id)
                        .Include(x => x.Order)
                        .Include(x => x.Item)
                        .Include(x => x.Order.Cook).ToList()
                        .GroupBy(x => x.Order).ToList();

                    ViewBag.Orders = orders;

                    ViewBag.IsUser = true;
                    ViewBag.Data = user;
                }
                else if (cook is not null)
                {
                    ViewBag.IsUser = false;
                    ViewBag.Data = cook;
                }

                return View();
            }
            else
                return RedirectToAction("Login", "Account");
        }
    }
}
