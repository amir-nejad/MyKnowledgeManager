namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events
{
    public class KnowledgeDeletedEevent : BaseDomainEvent
    {
        public Knowledge Knowledge { get; set; }

        public KnowledgeDeletedEevent(Knowledge knowledge)
        {
            Knowledge = knowledge;
        }
    }
}
