using MediatR;
using Refit;
using Tourmine.Application.Requests.Email;

namespace Tourmine.Application.Command.Email.SendEmail
{
    public class SendEmailCommand : IRequest<HttpResponseMessage>
    {
        public SendEmailRequest Request { get; set; }

        public SendEmailCommand(SendEmailRequest Request)
        {
            this.Request = Request;
        }
    }
}
