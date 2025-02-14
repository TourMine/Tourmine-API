using MediatR;
using Tourmine.Application.Command.Users.Login.ValidatePassword;
using Tourmine.Application.Queries.Users.GetUserByEmail;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Responses.Auth;
using Tourmine.Application.UseCase.Interfaces;
using Tourmine.Infrastructure.Interfaces;

namespace Tourmine.Application.UseCase.Auth
{
    public class LoginUseCase : BaseUseCase, ILoginUseCase
    {
        private readonly IJwtTokenService _tokenService;

        public LoginUseCase(IMediator mediator, IJwtTokenService tokenService) : base(mediator)
        {
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            var user = await mediator.Send(new GetUserByEmailQuery(request.Email));

            if(user == null)
                throw new UnauthorizedAccessException("Usuário não encontrado");

            bool isPasswordValid = await mediator.Send(new ValidatePasswordCommand(request));

            if(!isPasswordValid) 
                throw new UnauthorizedAccessException("E-mail ou senha inválidos.");

            var token = await _tokenService.GenerateToken(user);
            
            return new LoginResponse
            {
                Token = token.Token,
                ExpiresIn = token.ExpiresIn,
                IssuedAt = token.IssuedAt,
                ExpiresAt = token.ExpiresAt
            };
        }
    }
}
