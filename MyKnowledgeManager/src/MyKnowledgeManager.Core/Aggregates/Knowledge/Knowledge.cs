using Ardalis.GuardClauses;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Enums;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events;
using MyKnowledgeManager.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate
{
    /// <summary>
    /// This class is used for converting to "Knowledges" table and is the root of KnowledgeAggregate
    /// </summary>
    public class Knowledge : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; private set; }

        public KnowledgeLevel KonwledgeLevel { get; private set; } = KnowledgeLevel.Beginner;

        public KnowledgeImportance KnowledgeImportance { get; private set; } = KnowledgeImportance.Neutral;

        public IList<KnowledgeTag> KnowledgeTags { get; private set; } = new List<KnowledgeTag>();


        public Knowledge(string title, string description, KnowledgeLevel konwledgeLevel, 
            KnowledgeImportance knowledgeImportance)
        {
            Title = title;
            Description = description;
            KonwledgeLevel = konwledgeLevel;
            KnowledgeImportance = knowledgeImportance;
        }

        public void UpdateTitle(string newTitle)
        {
            Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
        }

        public void UpdateDescription(string newDescription)
        {
            Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
        }

        public void UpdateKnowledgeLevel(KnowledgeLevel newKnowledgeLevel)
        {
            KonwledgeLevel = newKnowledgeLevel;
        }

        public void UpdateKnowledgeTrashState(bool isTrashItem)
        {
            IsTrashItem = isTrashItem;

            Events.Add(new KnowledgeMovedToTrashEvent(this));
        }
    }
}
