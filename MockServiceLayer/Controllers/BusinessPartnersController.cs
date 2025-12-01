using Microsoft.AspNetCore.Mvc;

namespace MockServiceLayer.Controllers
{
    [ApiController]
    [Route("b1s/v1/[controller]")]
    public class BusinessPartnersController : Controller
    {
        private static readonly List<dynamic> _partners = new();

        [HttpPost]
        public IActionResult CreateBP([FromBody] dynamic body)
        {
            _partners.Add(body);
            return Ok(new { Result = "Mock BP created!", Data = body });
        }

        [HttpGet]
        public IActionResult GetBP()
        {
            return Ok(_partners);
        }
    }
}
