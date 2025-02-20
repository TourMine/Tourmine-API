using Refit;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Requests.Users;

namespace Tourmine.Application.ExternalServices.Interfaces
{
    public interface IUserService
    {
        [Post("/users/v1/register")]
        Task<HttpResponseMessage> Register([Body] RegisterUserRequest request);

        [Put("/users/v1/{id}")]
        Task<HttpResponseMessage> Update(Guid id, [Body] UpdateUserRequest request);

        [Post("/users/v1/validate-password")]
        Task<HttpResponseMessage> Login([Body] LoginRequest request);

        [Get("/users/v1/get-by-email")]
        Task<HttpResponseMessage> GetByEmail([Query] string email);
    }
}
