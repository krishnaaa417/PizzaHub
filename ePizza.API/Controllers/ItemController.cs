using ePizza.Core.Concrete;
using ePizza.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IitemService _itemService;
        public ItemController(IitemService itemService)
        {
            _itemService = itemService;
        }

        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _itemService.GetAllItems();
            return Ok(result);
        }
    }
}
