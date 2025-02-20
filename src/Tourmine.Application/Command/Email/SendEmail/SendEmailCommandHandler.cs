using MediatR;
using Microsoft.Extensions.Configuration;
using Refit;
using Tourmine.Application.ExternalServices.Email;
using Tourmine.Infrastructure;

namespace Tourmine.Application.Command.Email.SendEmail
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, HttpResponseMessage>
    {
        private readonly IConfiguration _configuration;
        public SendEmailCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var client = RestService.For<IEmailService>( _configuration["Email:BasePath"]!, new RefitSettings
            {
                AuthorizationHeaderValueGetter = (msg, token) => Task.FromResult($"Bearer {_configuration["Email:ApiKey"]}")
            });

            try
            {
                var response = await client.SendEmailAsync(request.Request);

                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(content);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar a requisição de envio de e-mail: {ex.Message}");
            }
        }
    }
}
