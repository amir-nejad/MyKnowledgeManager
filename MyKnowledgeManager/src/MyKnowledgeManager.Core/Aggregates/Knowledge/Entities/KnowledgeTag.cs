using MyKnowledgeManager.Core.Aggregates.Knowledge.Events;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Events;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Entities
{
    public class KnowledgeTag : BaseEntity
    {
        [Display(Name = "Tag Name")]
        public string TagName { get; private set; }

        public IEnumerable<KnowledgeTagRelation> KnowledgeTagRelations { get; private set; }

        public KnowledgeTag(string tagName)
        {
            TagName = tagName;
        }

        public void UpdateKnowledgeTagTrashState(bool isTrashItem)
        {
            IsTrashItem = isTrashItem;

            Events.Add(new KnowledgeTagMovedToTrashEvent(this));
        }
    }
}
