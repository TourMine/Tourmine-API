using System.ComponentModel.DataAnnotations;

namespace Tourmine.Application.Requests.Users
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
