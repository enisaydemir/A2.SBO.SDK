using Microsoft.AspNetCore.Mvc;
using SapIntegrationApi.DTOs;
using SapIntegrationApi.Services;

namespace SapIntegrationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly SapServiceLayerClient _sap;

        private CustomersController(SapServiceLayerClient sap)
        {
            _sap = sap;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            var result = await _sap.CreateCustomer(dto);
            return Ok(result);
        }
    }
}
