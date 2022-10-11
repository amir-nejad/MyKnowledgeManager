using MyKnowledgeManager.Core.Events;

namespace MyKnowledgeManager.Core.Entities
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
