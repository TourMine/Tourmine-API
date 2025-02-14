using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tourmine.Infrastructure.DTOs;
using Tourmine.Infrastructure.Interfaces;

namespace Tourmine.Infrastructure.Authentication
{
    public class JwtTokenService : IJwtTokenService
    {
        public async Task<TokenDTO> GenerateToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Settings.SecretKey);

            var issuedAt = DateTime.UtcNow;
            var expiresAt = issuedAt.AddHours(2);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDTO
            {
                Token = tokenHandler.WriteToken(token),
                ExpiresIn = (int)(expiresAt - issuedAt).TotalSeconds,
                IssuedAt = issuedAt.ToString("o"),
                ExpiresAt = expiresAt.ToString("o")
            };
        }
    }
}
