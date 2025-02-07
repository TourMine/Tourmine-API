using Microsoft.AspNetCore.Mvc;

namespace Tourmine.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpGet("v1/get-by-id")]
        public async Task<IActionResult> UserTest()
        {
            return Ok("olá");
        }
    }
}
