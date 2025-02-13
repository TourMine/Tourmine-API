using Microsoft.AspNetCore.Mvc;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.UseCase.Interfaces;

namespace Tourmine.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> UserTest([FromBody] RegisterUserRequest request, [FromServices] IRegisterUseCase useCase) 
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
