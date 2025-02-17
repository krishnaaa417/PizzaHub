using ePizza.UI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ePizza.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> Login(LoginModel login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var client = _httpClientFactory.CreateClient("ePizzaApiClient");
        //       var validuser =  await client.GetFromJsonAsync<bool>($"api/Auth?userName={login.UserName}&password={login.Password}");

        //        // do relevant functionality

        //        if (validuser)
        //        {
        //           return  RedirectToAction("Welcome");
        //        }
        //    }
        //    return View();
        //}

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

                var client = _httpClientFactory.CreateClient("ePizaaApiClient");

                // var validUser = await client.GetFromJsonAsync<bool>($"api/Auth?userName={loginModel.UserName}&password={loginModel.Password}");

                bool validUser = true;
                if (validUser)
                {
                    List<Claim> claims = new List<Claim>();

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    });

                    return RedirectToAction("Welcome");
                }
                // do relevant functionality
            }
            return View();
        }



        [HttpGet]
        [Authorize]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

    }
}
