using MediatR;
using Microsoft.Extensions.Configuration;
using Tourmine.Application.Command.Email.SendEmail;
using Tourmine.Application.Command.Users.Register;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Requests.Email;
using Tourmine.Application.Shared;
using Tourmine.Application.UseCase.Interfaces;

namespace Tourmine.Application.UseCase.User
{
    public class RegisterUseCase : BaseUseCase, IRegisterUseCase
    {
        private readonly IConfiguration _configuration;
        public RegisterUseCase(IMediator mediator, IConfiguration configuration) : base(mediator)
        {
            _configuration = configuration;
        }

        public async Task<bool> Execute(RegisterUserRequest request)
        {
            try
            {
                var validateEnum = ValidateEnum.ValidateUserType(request.UserType);

                if (!validateEnum)
                    throw new Exception("Invalid user type");

                var result = await mediator.Send(new RegisterUserCommand(request));

                var sendEmailRequest = new SendEmailRequest
                {
                    From = new EmailSender { Email = _configuration["Email:Senders:DefaultSender"]! },
                    Subject = "Cadastro Realizado no site TourMine",
                    template_id = _configuration["Email:Templates:WellCome"]!,
                    To = new List<EmailRecipient> { new EmailRecipient { Email = request.Email } },
                    Personalization = new List<Personalization>
                        { new Personalization
                            {
                                Email = request.Email,
                                Data = new Dictionary<string, string>() { { "name", request.Name } }
                            }
                        }
                };

                await mediator.Send(new SendEmailCommand(sendEmailRequest));

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
