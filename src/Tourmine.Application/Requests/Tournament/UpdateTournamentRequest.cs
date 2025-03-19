namespace Tourmine.Application.Requests.Tournament
{
    public class UpdateTournamentRequest
    {
        public string Name { get; set; }
        public string Game { get; set; }
        public EPlataforms Plataform { get; set; }
        public int MaxTeams { get; set; }
        public EParticipantsType TeamsType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Prize { get; set; }
        public ESubscriptionType SubscriptionType { get; set; }
        public ETournamentStatus Status { get; set; }
        public string? Description { get; set; }
    }
}
