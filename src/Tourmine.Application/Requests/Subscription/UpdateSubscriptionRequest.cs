namespace Tourmine.Application.Requests.Subscription
{
    public class UpdateSubscriptionRequest
    {
        public ESubscriptionStatus Status { get; set; }
    }

    public enum ESubscriptionStatus
    {
        ACTIVE = 1,
        DESACTIVE = 2
    }
}
