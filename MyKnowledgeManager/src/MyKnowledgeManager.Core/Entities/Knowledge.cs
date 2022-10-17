using Ardalis.GuardClauses;
using MyKnowledgeManager.Core.Enums;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Entities
{
    /// <summary>
    /// This class is used for converting to "Knowledges" table and is the root of Knowledge
    /// </summary>
    public class Knowledge : BaseEntity
    {
        private List<KnowledgeTagRelation> _knowledgeTagRelations = new List<KnowledgeTagRelation>();
        public string Title { get; private set; }

        public string Description { get; private set; }

        public KnowledgeLevel KnowledgeLevel { get; private set; } = KnowledgeLevel.Beginner;

        public KnowledgeImportance KnowledgeImportance { get; private set; } = KnowledgeImportance.Neutral;

        public string ApplicationUserId { get; private set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IEnumerable<KnowledgeTagRelation> KnowledgeTagRelations => _knowledgeTagRelations;


        public Knowledge(string title, string description, KnowledgeLevel knowledgeLevel,
            KnowledgeImportance knowledgeImportance)
        {
            Title = title;
            Description = description;
            KnowledgeLevel = knowledgeLevel;
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
            KnowledgeLevel = newKnowledgeLevel;
        }

        public override void ChangeTrashState(bool isTrashItem = false)
        {
            base.ChangeTrashState(isTrashItem);
            Events.Add(new TrashStateChanged<Knowledge>(this));
        }
    }
}
