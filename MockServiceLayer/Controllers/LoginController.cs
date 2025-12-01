using Microsoft.AspNetCore.Mvc;

namespace MockServiceLayer.Controllers
{
    [ApiController]
    [Route("b1s/v1/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] object body)
        {
            return Ok(new
            {
                SessionId = Guid.NewGuid().ToString(),
                Version = "MockServiceLayer 1.0"
            });
        }
    }
}
