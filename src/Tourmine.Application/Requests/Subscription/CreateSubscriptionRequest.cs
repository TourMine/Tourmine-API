namespace Tourmine.Application.Requests.Subscription
{
    public class CreateSubscriptionRequest
    {
        public Guid TournamentId { get; set; }
        public Guid UserId { get; set; }
    }
}
