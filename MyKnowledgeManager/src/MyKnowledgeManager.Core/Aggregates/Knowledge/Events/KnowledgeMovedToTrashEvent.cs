namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events
{
    public class KnowledgeMovedToTrashEvent : BaseDomainEvent
    {
        public Knowledge Knowledge { get; set; }

        public KnowledgeMovedToTrashEvent(Knowledge knowledge)
        {
            Knowledge = knowledge;
        }
    }
}
