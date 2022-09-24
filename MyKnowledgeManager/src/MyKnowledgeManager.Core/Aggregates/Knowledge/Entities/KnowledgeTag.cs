using MyKnowledgeManager.Core.Aggregates.Knowledge.Events;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Entities
{
    public class KnowledgeTag : BaseEntity
    {
        [Display(Name = "Tag Name")]
        public string TagName { get; private set; } = string.Empty;

        [Display(Name = "Knowledge")]
        public string KnowledgeId { get; private set; } = string.Empty;

        public Knowledge Knowledge { get; private set; } = null;

        public KnowledgeTag(string tagName, string knowledgeId, Knowledge knowledge)
        {
            TagName = tagName;
            KnowledgeId = knowledgeId;
            Knowledge = knowledge;
        }

        public void UpdateKnowledgeTagTrashState(bool isTrashItem)
        {
            IsTrashItem = isTrashItem;

            Events.Add(new KnowledgeTagMovedToTrashEvent(this));
        }
    }
}
