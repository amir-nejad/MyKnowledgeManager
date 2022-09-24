namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events
{
    public class KnowledgeDeletedEevent : BaseDomainEvent
    {
        public Knowledge.Entities.Knowledge Knowledge { get; set; }

        public KnowledgeDeletedEevent(Knowledge.Entities.Knowledge knowledge)
        {
            Knowledge = knowledge;
        }
    }
}
