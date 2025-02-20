using MediatR;
using Tourmine.Application.Command.Users.Update;
using Tourmine.Application.Requests.Users;
using Tourmine.Application.UseCase.Interfaces.Users;

namespace Tourmine.Application.UseCase.User
{
    public class UpdateUserUseCase : BaseUseCase, IUpdateUserUseCase
    {
        public UpdateUserUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(Guid id, UpdateUserRequest request)
        {
            return await mediator.Send(new UpdateUserCommand(id, request));
        }
    }
}
