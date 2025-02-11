using MediatR;
using Tourmine.Application.Responses.Auth;

namespace Tourmine.Application.Command.Auth.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IAuthService _service;

        public RegisterUserCommandHandler(IAuthService service)
        {
            _service = service;
        }

        public Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
