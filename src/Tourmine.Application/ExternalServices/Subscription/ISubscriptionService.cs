using Refit;
using Tourmine.Application.Requests.Subscription;

namespace Tourmine.Application.ExternalServices.Subscription
{
    public interface ISubscriptionService
    {
        [Post("/subscription/v1/create")]
        Task<HttpResponseMessage> Create([Body] CreateSubscriptionRequest request);

        [Get("/subscription/v1/{UserId}")]
        Task<HttpResponseMessage> GetAllByUserId(
            Guid id,
            [Query] int start = 0,
            [Query] int limit = 25
            );

        [Put("/subscription/v1/{UserId}/{TournamentId}")]
        Task<HttpResponseMessage> Update(
            Guid UserId,
            Guid TournamentId,
            [Body] UpdateSubscriptionRequest request);

        [Get("/subscription/v1/get-by-tournamentId/{tournamentId}")]
        Task<HttpResponseMessage> GetAll(
            Guid TournamentId,
            [Query] GetAllSubscriptionByTournamentIdRequest request);
    }
}
