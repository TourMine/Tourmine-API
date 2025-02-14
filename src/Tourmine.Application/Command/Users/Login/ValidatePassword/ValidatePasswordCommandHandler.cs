using MediatR;
using Refit;
using Tourmine.Application.ExternalServices.Interfaces;
using Tourmine.Infrastructure;

namespace Tourmine.Application.Command.Users.Login.ValidatePassword
{
    public class ValidatePasswordCommandHandler : IRequestHandler<ValidatePasswordCommand, bool>
    {
        public async Task<bool> Handle(ValidatePasswordCommand request, CancellationToken cancellationToken)
        {
            var client = RestService.For<IUserService>(Settings.UserBasePath);

            try
            {
                var response = await client.Login(request.Request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao registrar usuário: {errorContent}");
            }
            catch (Refit.ValidationApiException ex)
            {
                Console.WriteLine($"Erro na requisição: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na requisição: {ex.Message}");
                throw;
            }
        }
    }
}
