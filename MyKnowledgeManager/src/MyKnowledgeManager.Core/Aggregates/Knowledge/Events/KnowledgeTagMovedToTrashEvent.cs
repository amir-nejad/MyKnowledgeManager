using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Events
{
    public class KnowledgeTagMovedToTrashEvent : BaseDomainEvent
    {
        public KnowledgeTag KnowledgeTag { get; set; }

        public KnowledgeTagMovedToTrashEvent(KnowledgeTag knowledgeTag)
        {
            KnowledgeTag = knowledgeTag;
        }
    }
}
