using Tourmine.Application.Requests.Auth;

namespace Tourmine.Application.UseCase.Interfaces.Users
{
    public interface IRegisterUseCase
    {
        Task<bool> Execute(RegisterUserRequest request);
    }
}
