namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Events
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
