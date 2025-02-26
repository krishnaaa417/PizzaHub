using ePizza.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ePizza.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewData["message"] = "Welcome to ePizza!";
            ViewBag.message = "Hello Krishna...";
            return View();
        }

        public IActionResult Privacy()
        {

            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
