using Microsoft.AspNetCore.Mvc;
using Tourmine.Application.Requests.Users;
using Tourmine.Application.UseCase.Interfaces.Users;

namespace Tourmine.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpPut("v1/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request, [FromServices] IUpdateUserUseCase useCase)
        {
            var result = await useCase.Execute(id, request);
            return Ok(result);
        }

    }
}
