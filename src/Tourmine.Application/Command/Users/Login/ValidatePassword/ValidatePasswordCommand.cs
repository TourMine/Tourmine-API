using MediatR;
using Tourmine.Application.Requests.Auth;

namespace Tourmine.Application.Command.Users.Login.ValidatePassword
{
    public class ValidatePasswordCommand : IRequest<bool>
    {
        public LoginRequest Request { get; set; }

        public ValidatePasswordCommand(LoginRequest request)
        {
            Request = request;
        }
    }
}
