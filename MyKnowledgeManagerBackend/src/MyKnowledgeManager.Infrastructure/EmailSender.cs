using Microsoft.Extensions.Logging;
using MyKnowledgeManager.Core.Interfaces;
using System.Net.Mail;

namespace MyKnowledgeManager.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private const string defaultSenderEmail = "noreply@myknowledgemanager.ir";

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailClient = new SmtpClient("localhost");
            var message = new MailMessage
            {

                From = new MailAddress(defaultSenderEmail),
                Subject = subject,
                Body = body


            };
            message.To.Add(new MailAddress(to));
            await emailClient.SendMailAsync(message);
            _logger.LogWarning("Sending email to {to} from {from} with subject {subject}.", to, defaultSenderEmail, subject);
        }
    }
}