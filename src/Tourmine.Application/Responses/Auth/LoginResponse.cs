namespace Tourmine.Application.Responses.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public string IssuedAt { get; set; }
        public string ExpiresAt { get; set; }
    }
}
