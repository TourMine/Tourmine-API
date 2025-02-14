using MediatR;
using Newtonsoft.Json;
using Refit;
using Tourmine.Application.ExternalServices.Interfaces;
using Tourmine.Infrastructure;
using Tourmine.Infrastructure.DTOs;

namespace Tourmine.Application.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
    {
        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var client = RestService.For<IUserService>(Settings.UserBasePath);

            try
            {
                var response = await client.GetByEmail(request.Email);

                if (response.IsSuccessStatusCode)
                {
                    var contentReturned = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserDTO>(contentReturned);
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao encontrar o usuário: {errorContent}");
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
