using MediatR;
using Tourmine.Application.Requests.Users;

namespace Tourmine.Application.Command.Users.Update
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateUserRequest Request { get; set; }

        public UpdateUserCommand(Guid id, UpdateUserRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
