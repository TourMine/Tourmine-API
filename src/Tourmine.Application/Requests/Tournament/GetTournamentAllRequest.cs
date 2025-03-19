namespace Tourmine.Application.Requests.Tournament
{
    public class GetTournamentAllRequest
    {
        public EPlataforms? plataforms { get; set; }
        public EParticipantsType? teamsTypes { get; set; }
        public ESubscriptionType? subscriptionTypes { get; set; }
    }
}
