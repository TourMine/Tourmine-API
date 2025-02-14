using MediatR;

namespace Tourmine.Application.UseCase
{
    public abstract class BaseUseCase
    {
        protected readonly IMediator mediator;

        protected BaseUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
