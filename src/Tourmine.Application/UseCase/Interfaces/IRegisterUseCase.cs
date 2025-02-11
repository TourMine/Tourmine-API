using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Responses.Auth;

namespace Tourmine.Application.UseCase.Interfaces
{
    public interface IRegisterUseCase
    {
        Task<RegisterUserResponse> Execute(RegisterUserRequest request);
    }
}
