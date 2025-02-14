namespace Tourmine.Infrastructure.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Enum UserType { get; set; }
    }

    public enum Enum
    {
        Organizer = 1,
        Player = 2
    }
}
