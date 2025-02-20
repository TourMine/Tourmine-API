namespace Tourmine.Application.Requests.Email
{
    public class SendEmailRequest
    {
        public EmailSender From { get; set; }
        public List<EmailRecipient> To { get; set; }
        public string Subject { get; set; }
        public string template_id { get; set; } // Corrigido para 'template_id'
        public List<Personalization> Personalization { get; set; }
    }

    public class EmailSender
    {
        public string Email { get; set; }
    }

    public class EmailRecipient
    {
        public string Email { get; set; }
    }

    public class Personalization
    {
        public string Email { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}