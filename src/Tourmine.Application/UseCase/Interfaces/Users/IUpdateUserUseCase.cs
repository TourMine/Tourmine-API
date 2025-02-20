using Tourmine.Application.Requests.Users;

namespace Tourmine.Application.UseCase.Interfaces.Users
{
    public interface IUpdateUserUseCase
    {
        Task<bool> Execute(Guid id, UpdateUserRequest request);
    }
}
