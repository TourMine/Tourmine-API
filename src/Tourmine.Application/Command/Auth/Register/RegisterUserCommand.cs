using MediatR;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Responses.Auth;

namespace Tourmine.Application.Command.Auth.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public RegisterUserRequest Request { get; set; }

        public RegisterUserCommand(RegisterUserRequest request)
        {
            Request = request;
        }
    }
}
