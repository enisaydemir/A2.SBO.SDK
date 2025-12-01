using Microsoft.AspNetCore.Mvc;
using SapIntegrationApi.DTOs;
using SapIntegrationApi.Services;

namespace SapIntegrationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly SapServiceLayerClient _sap;

        public OrdersController(SapServiceLayerClient sap)
        {
            _sap = sap;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            var result = await _sap.CreateOrder(dto);
            return Ok(result);
        }
    }
}
