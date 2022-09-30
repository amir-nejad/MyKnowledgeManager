﻿namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events
{
    public class KnowledgeMovedToTrashEvent : BaseDomainEvent
    {
        public Knowledge.Entities.Knowledge Knowledge { get; set; }

        public KnowledgeMovedToTrashEvent(Knowledge.Entities.Knowledge knowledge)
        {
            Knowledge = knowledge;
        }
    }
}