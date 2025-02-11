using System.ComponentModel.DataAnnotations;

namespace Tourmine.Application.Requests.Auth
{
    public class RegisterUserRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [EnumDataType(typeof(EUserRole))]
        public EUserRole UserRole { get; set; }
    }

    public enum EUserRole
    {
        Organizer = 1,
        Player = 2
    }
}
