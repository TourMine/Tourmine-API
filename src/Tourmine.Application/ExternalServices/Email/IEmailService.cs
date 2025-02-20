using Refit;
using Tourmine.Application.Requests.Email;

namespace Tourmine.Application.ExternalServices.Email
{
    public interface IEmailService
    {
        [Post("/email")]
        [Headers("X-Requested-With: XMLHttpRequest", "Authorization: Bearer")]
        Task<HttpResponseMessage> SendEmailAsync([Body] SendEmailRequest request);
    }
}
