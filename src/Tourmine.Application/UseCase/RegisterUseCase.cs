using MediatR;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Responses.Auth;
using Tourmine.Application.UseCase.Interfaces;

namespace Tourmine.Application.UseCase
{
    public class RegisterUseCase : BaseUseCase, IRegisterUseCase
    {
        public RegisterUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<RegisterUserResponse> Execute(RegisterUserRequest request)
        {
            return await _mediator.Send(new RegisterUserCommand(request));
        }
    }
}
