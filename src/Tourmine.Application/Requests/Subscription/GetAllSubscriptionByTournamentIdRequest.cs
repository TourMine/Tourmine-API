using Tourmine.Application.Requests.Tournament;

namespace Tourmine.Application.Requests.Subscription
{
    public class GetAllSubscriptionByTournamentIdRequest
    {
        public ETournamentStatus Status { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
    }
}
