using ePizza.UI.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ePizzaApiClient");
               var validuser =  await client.GetFromJsonAsync<bool>($"api/Auth?userName={login.UserName}&password={login.Password}");

                // do relevant functionality

                if (validuser)
                {
                   return  RedirectToAction("Welcome");
                }
            }
            return View(login);
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }

    }
}
