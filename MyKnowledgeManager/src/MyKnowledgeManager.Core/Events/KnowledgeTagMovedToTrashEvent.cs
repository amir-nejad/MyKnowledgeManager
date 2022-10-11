using MyKnowledgeManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Events
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
