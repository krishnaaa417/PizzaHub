using ePizza.Core.Contracts;
using ePizza.Core.Utils;
using ePizza.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly TokenGenerator _tokenGenerator;

        public AuthController(IAuthService authService, TokenGenerator tokenGenerator)
        {
            _authService = authService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateUser(string username, string password)
        {
            //Json

            var userDetails = _authService.ValidateUser(username, password);

            if (userDetails != null)
            {
                var securityToken = _tokenGenerator.GenerateToken(userDetails);
                return Ok(securityToken);
            }

            return Ok(userDetails);
        }
    }
}
