using MediatR;
using Tourmine.Infrastructure.DTOs;

namespace Tourmine.Application.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
