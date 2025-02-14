using Tourmine.Infrastructure.DTOs;

namespace Tourmine.Infrastructure.Interfaces
{
    public interface IJwtTokenService
    {
        Task<TokenDTO> GenerateToken(UserDTO user);
    }
}
