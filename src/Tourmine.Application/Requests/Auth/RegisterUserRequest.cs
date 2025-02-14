using System.ComponentModel.DataAnnotations;

namespace Tourmine.Application.Requests.Auth
{
    public class RegisterUserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public int UserType { get; set; }
    }

    public enum EUserType
    {
        Organizer = 1,
        Player = 2
    }
}
