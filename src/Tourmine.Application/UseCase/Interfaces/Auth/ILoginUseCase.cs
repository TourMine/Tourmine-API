using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Responses.Auth;

namespace Tourmine.Application.UseCase.Interfaces.Auth
{
    public interface ILoginUseCase
    {
        Task<LoginResponse> Execute(LoginRequest request);
    }
}
