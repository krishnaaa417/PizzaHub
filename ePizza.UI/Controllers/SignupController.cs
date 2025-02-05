using ePizza.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePizza.UI.Controllers
{
    
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel sign)
        {
            return View();
        }
    }
}
