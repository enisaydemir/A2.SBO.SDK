using Microsoft.AspNetCore.Mvc;
using MockServiceLayer.DTOs;

namespace MockServiceLayer.Controllers
{
    [ApiController]
    [Route("b1s/v1/[controller]")]
    public class OrdersController : Controller
    {
        private static readonly List<dynamic> _orders = new();

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto dto)
        {
            dto.DocEntry = _orders.Count + 1;
            _orders.Add(dto);

            return Ok(new
            {
                Result = "Mock Order created!",
                Data = dto
            });
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(_orders);
        }
    }
}
