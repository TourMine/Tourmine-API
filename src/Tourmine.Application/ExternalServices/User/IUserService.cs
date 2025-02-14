using Refit;
using Tourmine.Application.Requests.Auth;

namespace Tourmine.Application.ExternalServices.Interfaces
{
    public interface IUserService
    {
        [Post("/users/v1/register")]
        Task<HttpResponseMessage> Register([Body] RegisterUserRequest request);

        [Post("/users/v1/validate-password")]
        Task<HttpResponseMessage> Login([Body] LoginRequest request);

        [Get("/users/v1/get-by-email")]
        Task<HttpResponseMessage> GetByEmail([Query] string email);
    }
}
