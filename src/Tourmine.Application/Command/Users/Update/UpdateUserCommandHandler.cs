using MediatR;
using Refit;
using Tourmine.Application.ExternalServices.Interfaces;
using Tourmine.Infrastructure;

namespace Tourmine.Application.Command.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var client = RestService.For<IUserService>(Settings.UserBasePath);

            try
            {
                var response = await client.Update(request.Id, request.Request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao atualizar usuário: {errorContent}");
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
