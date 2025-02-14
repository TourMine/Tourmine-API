using Tourmine.Application.Requests.Auth;

namespace Tourmine.Application.UseCase.Interfaces
{
    public interface IRegisterUseCase
    {
        Task<bool> Execute(RegisterUserRequest request);
    }
}
