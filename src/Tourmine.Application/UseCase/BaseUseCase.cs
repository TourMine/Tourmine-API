using MediatR;

namespace Tourmine.Application.UseCase
{
    public abstract class BaseUseCase
    {
        protected readonly IMediator _mediator;

        protected BaseUseCase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
