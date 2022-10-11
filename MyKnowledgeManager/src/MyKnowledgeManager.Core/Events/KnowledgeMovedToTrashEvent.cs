namespace MyKnowledgeManager.Core.Events
{
    public class KnowledgeMovedToTrashEvent : BaseDomainEvent
    {
        public Entities.Knowledge Knowledge { get; set; }

        public KnowledgeMovedToTrashEvent(Entities.Knowledge knowledge)
        {
            Knowledge = knowledge;
        }
    }
}
