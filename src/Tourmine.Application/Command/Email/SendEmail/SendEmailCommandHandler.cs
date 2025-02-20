using MediatR;
using Refit;
using Tourmine.Application.ExternalServices.Email;
using Tourmine.Infrastructure;

namespace Tourmine.Application.Command.Email.SendEmail
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, HttpResponseMessage>
    {
        public async Task<HttpResponseMessage> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            // inserir uri padrão para appsettings
            var client = RestService.For<IEmailService>("https://api.mailersend.com/v1", new RefitSettings
            {
                AuthorizationHeaderValueGetter = (msg, token) => Task.FromResult($"Bearer {Settings.EmailSecretKey}")
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
