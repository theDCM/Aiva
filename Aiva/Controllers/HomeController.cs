﻿using Aiva.Data;
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
            ViewBag.Menu = context.Items;
            ViewBag.IsAuthorized = base.User.Identity.IsAuthenticated;

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
                return View();
            else
                return RedirectToAction("Login", "Home");
        }

        [HttpGet("/user")]
        public IActionResult User()
        {
            if (base.User.Identity.IsAuthenticated)
            {
                var login = base.User.Identity.Name;

                var user = db.Clients.FirstOrDefault(x => x.Login == login);
                var cook = db.Cooks.Include(x => x.Kitchen).FirstOrDefault(x => x.Login == login);

                if (user is null && cook is null)
                    return RedirectToAction("Index", "Home");

                if (user is not null)
                {
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
