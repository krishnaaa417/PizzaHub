using ePizza.Core.Contracts;
using ePizza.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAction")]
        [HttpGet]
        
        public async Task< IActionResult> GetAction()
        {
           var userresponse =  _userService.GetAllUsers();
            return Ok(userresponse);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserRequest createUserRequest)
        {
            if (ModelState.IsValid)
            { 
                var createuser = _userService.AddUser(createUserRequest);
                return Ok();
            }
            return BadRequest(ModelState.Select(x => x.Key));

        }

        
        }
    }
