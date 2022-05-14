using Aiva.Data;
using Aiva.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        private System.Random random;

        public ApiController(DatabaseContext context)
        {
            db = context;
            random = new Random();
        }

        [HttpPost("create_order")]
        public async Task<IActionResult> CreateOrder([FromBody] string address)
        {
            var client = db.Clients.First(x => x.Login == User.Identity.Name);

            var order = new Order()
            {
                Address = address,
                Client = client,
                CreatedAt = DateTime.Now,
                Number = random.Next().ToString(),
                State = OrderState.Created,
                Price = GetOrderPrice(client),
            };

            db.Orders.Add(order);

            var cartItems = db.CartItems.Where(x => x.Client.Id == client.Id).Include(x => x.Item);

            foreach (var cartItem in cartItems)
            {
                db.OrderItems.Add(new OrderItem()
                {
                    Count = cartItem.Count,
                    Item = cartItem.Item,
                    Order = order
                });
            }

            db.CartItems.RemoveRange(cartItems);

            db.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// итоговая стоимость заказа
        /// </summary>
        private decimal GetOrderPrice(Client client)
        {
            var userCart = db.CartItems.Where(x => x.Client.Id == client.Id);
            return userCart.Sum(x => x.Item.Price * x.Count);
        }

        [HttpPost("addtocart")]
        public async Task<IActionResult> AddToCart([FromBody] int itemId)
        {
            //TODO: отображение заказа у повара
            //TODO: отображение состояния заказа у клиента
            if (User.Identity.IsAuthenticated)
            {
                var login = User.Identity.Name;

                var user = await db.Clients.FirstOrDefaultAsync(x => x.Login == login);

                var item = await db.Items.FirstOrDefaultAsync(x => x.Id == itemId);

                var cartItem = await db.CartItems.FirstOrDefaultAsync(x => x.Item == item && x.Client == user);

                if (cartItem is null)
                {
                    await db.CartItems.AddAsync(new CartItem()
                    {
                        Client = user,
                        Count = 1,
                        Item = item
                    });
                }
                else
                {
                    cartItem.Count += 1;
                    db.CartItems.Update(cartItem);
                }

                await db.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("plus_one")]
        public async Task<IActionResult> plus_one([FromBody] int cartId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var login = User.Identity.Name;

                var cartItem = await db.CartItems.FirstOrDefaultAsync(x => x.Id == cartId);

                if (cartItem is null)
                {
                    return Ok();
                }
                else
                {
                    cartItem.Count++;
                    db.CartItems.Update(cartItem);
                }

                await db.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("minus_one")]
        public async Task<IActionResult> minus_one([FromBody] int cartId)
        {
            if (base.User.Identity.IsAuthenticated)
            {
                var login = base.User.Identity.Name;

                var cartItem = await db.CartItems.FirstOrDefaultAsync(x => x.Id == cartId);

                if (cartItem is null)
                {
                    return Ok();
                }
                else
                {
                    cartItem.Count--;
                    db.CartItems.Update(cartItem);
                }

                await db.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("deletefromcart")]
        public async Task<IActionResult> deletefromcart([FromBody] int cartId)
        {
            if (base.User.Identity.IsAuthenticated)
            {
                var login = base.User.Identity.Name;

                var cartItem = await db.CartItems.FirstOrDefaultAsync(x => x.Id == cartId);

                if (cartItem is null)
                {
                    return Ok();
                }
                else
                {
                    db.CartItems.Remove(cartItem);
                }

                await db.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                else
                {
                    Cook cook = await db.Cooks.FirstOrDefaultAsync(x => x.Login == loginModel.Login);
                    if (cook is not null)
                    {
                        await Authenticate(loginModel.Login); // аутентификация

                        return RedirectToAction("Index", "Home");
                    }
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
            return Content("<html><meta charset='utf-8'><script>alert(\"Ошибка при валидации модели: " + modelErrors + "\");document.location.href='/signup';</script></html>", "text/html");
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
