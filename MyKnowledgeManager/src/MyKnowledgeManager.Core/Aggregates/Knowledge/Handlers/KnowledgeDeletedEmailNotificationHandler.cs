using Ardalis.GuardClauses;
using MediatR;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events;
using MyKnowledgeManager.Core.Interfaces;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Handlers
{
    public class KnowledgeDeletedEmailNotificationHandler : INotificationHandler<KnowledgeDeletedEevent>
    {
        private readonly IEmailSender _emailSender;

        public KnowledgeDeletedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Handle(KnowledgeDeletedEevent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            return _emailSender.SendEmailAsync("ashabani500@gmail.com",
                $"One Knowledge Deleted at [{domainEvent.DateOccurred}]UTC",
                $"One knowledge deleted at {domainEvent.DateOccurred}UTC. Knowledge Title: {domainEvent.Knowledge.Title}");
        }
    }
}
