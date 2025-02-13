using MediatR;
using Tourmine.Application.Command.Auth.Register;
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
            //var user = await _mediator.Send(new GetUserByEmailQuery()); // TODO: Validar se o usuário existe no banco

            //if (user == null)
            //    return null;



            return await _mediator.Send(new RegisterUserCommand(request));
        }
    }
}
