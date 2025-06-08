using Microsoft.AspNetCore.Mvc;

namespace SmartNature.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok("✅ SmartNature API está funcionando!");
        }
    }
}
