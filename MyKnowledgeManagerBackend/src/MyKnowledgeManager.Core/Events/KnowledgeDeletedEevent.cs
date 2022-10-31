namespace MyKnowledgeManager.Core.Events
{
    public class KnowledgeDeletedEevent : BaseDomainEvent
    {
        public Entities.Knowledge Knowledge { get; set; }

        public KnowledgeDeletedEevent(Entities.Knowledge knowledge)
        {
            Knowledge = knowledge;
        }
    }
}
