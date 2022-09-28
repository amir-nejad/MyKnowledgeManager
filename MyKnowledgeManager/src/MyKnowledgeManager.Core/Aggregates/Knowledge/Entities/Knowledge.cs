using Ardalis.GuardClauses;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Enums;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events;
using MyKnowledgeManager.Core.Aggregates.User.Entities;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Entities
{
    /// <summary>
    /// This class is used for converting to "Knowledges" table and is the root of KnowledgeAggregate
    /// </summary>
    public class Knowledge : BaseEntity, IAggregateRoot
    {
        private List<KnowledgeTagRelation> _knowledgeTagRelations = new List<KnowledgeTagRelation>(); 
        public string Title { get; private set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; private set; }

        public KnowledgeLevel KonwledgeLevel { get; private set; } = KnowledgeLevel.Beginner;

        public KnowledgeImportance KnowledgeImportance { get; private set; } = KnowledgeImportance.Neutral;

        public string ApplicationUserId { get; private set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual IEnumerable<KnowledgeTagRelation> KnowledgeTagRelations => _knowledgeTagRelations;


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
