using ePizza.Core.Concrete;
using ePizza.Core.Contracts;
using ePizza.Models.Request;
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
            int i = 3;
            Console.WriteLine(Math.Pow(3,i));
        }

        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _itemService.GetAllItems();
            return Ok(result);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] ItemRequest request)
        {
            var items =_itemService.AddItem(request);
            return Ok(items);
        }
    }
}
