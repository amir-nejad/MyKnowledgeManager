using MyKnowledgeManager.Core.Interfaces;

namespace MyKnowledgeManager.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}