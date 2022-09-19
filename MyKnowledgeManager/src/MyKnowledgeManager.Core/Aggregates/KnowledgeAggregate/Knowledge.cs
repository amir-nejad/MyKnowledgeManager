using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Enums;
using MyKnowledgeManager.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate
{
    public class Knowledge : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public KnowledgeLevel KonwledgeLevel { get; private set; } = KnowledgeLevel.Beginner;

        public KnowledgeImportance KnowledgeImportance { get; private set; } = KnowledgeImportance.Neutral;

        public IList<KnowledgeTag> KnowledgeTags { get; private set; } = new List<KnowledgeTag>();


        public Knowledge(string title, string description, KnowledgeLevel konwledgeLevel, 
            KnowledgeImportance knowledgeImportance, IList<KnowledgeTag> knowledgeTags)
        {
            Title = title;
            Description = description;
            KonwledgeLevel = konwledgeLevel;
            KnowledgeImportance = knowledgeImportance;
            KnowledgeTags = knowledgeTags;
        }



    }
}
