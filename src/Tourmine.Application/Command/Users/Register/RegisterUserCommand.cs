using MediatR;
using Tourmine.Application.Requests.Auth;

namespace Tourmine.Application.Command.Users.Register
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public RegisterUserRequest Request { get; set; }

        public RegisterUserCommand(RegisterUserRequest request)
        {
            Request = request;
        }
    }
}
