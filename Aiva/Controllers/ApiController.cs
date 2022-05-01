using Aiva.Data;
using Aiva.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aiva.Controllers
{
    [Route("/api")]
    public class ApiController : Controller
    {
        private DatabaseContext db;

        public ApiController(DatabaseContext context)
        {
            db = context;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Client user = await db.Clients.FirstOrDefaultAsync(u => u.Login == loginModel.Login);
                if (user != null)
                {
                    await Authenticate(loginModel.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
            }
            return Content("<html><meta charset=\"utf-8\"><script>alert(\"Некорректные логин и(или) пароль\");document.location.href=\"/login\";</script></html>", "text/html");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await DoLogout();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                Client user = await db.Clients.FirstOrDefaultAsync(u => u.Login == registerModel.Login);
                Cook cook = await db.Cooks.FirstOrDefaultAsync(u => u.Login == registerModel.Login);
                if (user is null && cook is null)
                {
                    if (registerModel.Group1.Contains("Cook"))
                    {
                        await db.Cooks.AddAsync(
                            new Cook()
                            {
                                Kitchen = await db.Kitchen.FirstAsync(x => x.Id == registerModel.Kitchen),
                                Login = registerModel.Login,
                                FirstName = registerModel.FirstName,
                                LastName = registerModel.LastName,
                                Password = registerModel.Password,
                                Phone = registerModel.Phone,
                                BirthdayDate = registerModel.BirthdayDate
                            });
                    }
                    else if (registerModel.Group1.Contains("Client"))
                    {
                        await db.Clients.AddAsync(
                            new Client()
                            {
                                Login = registerModel.Login,
                                FirstName = registerModel.FirstName,
                                LastName = registerModel.LastName,
                                Password = registerModel.Password,
                                Phone = registerModel.Phone,
                                BirthdayDate = registerModel.BirthdayDate,
                            });
                    }
                    db.SaveChanges();
                    await Authenticate(registerModel.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
            }
            var modelErrors = string.Join(", ", ModelState.Values.Where(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).SelectMany(x => x.Errors.Select(x => x.ErrorMessage)));

            //return Content("<html><meta charset=\"utf-8\"><script>alert(\"Некорректные логин и(или) пароль\");document.location.href=\"/login\";</script></html>", "text/html");
            return Content("<html><meta charset='utf-8'><script>alert(\"Ошибка при валидации модели: "+ modelErrors + "\");document.location.href='/signup';</script></html>", "text/html");
        }


        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task DoLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
