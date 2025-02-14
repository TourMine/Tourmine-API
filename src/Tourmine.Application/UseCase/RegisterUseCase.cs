using MediatR;
using Tourmine.Application.Command.Users.Register;
using Tourmine.Application.Requests.Auth;
using Tourmine.Application.Shared;
using Tourmine.Application.UseCase.Interfaces;

namespace Tourmine.Application.UseCase
{
    public class RegisterUseCase : BaseUseCase, IRegisterUseCase
    {
        public RegisterUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(RegisterUserRequest request)
        {
            try
            {
                var validateEnum = ValidateEnum.ValidateUserType(request.UserType);

                if(!validateEnum)
                    throw new Exception("Invalid user type");

                var result = await mediator.Send(new RegisterUserCommand(request));
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
