using Refit;
using Tourmine.Application.Requests.Tournament;

namespace Tourmine.Application.ExternalServices.Tournament
{
    public interface ITournamentService
    {
        [Post("/tournament/v1/create")]
        Task<HttpResponseMessage> Register([Body] CreateTournamentRequest request);

        [Get("/tournament/v1/{id}")]
        Task<HttpResponseMessage> GetById([Query] Guid id);

        [Put("/tournament/v1/{id}")]
        Task<HttpResponseMessage> Update(Guid id, [Body] UpdateTournamentRequest request);

        [Get("/tournament/v1/all")]
        Task<HttpResponseMessage> GetAll([Query] GetTournamentAllRequest request, int start = 0, int limit = 25);
    }
}
