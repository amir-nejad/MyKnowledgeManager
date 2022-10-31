
namespace MyKnowledgeManager.Core.Entities
{
    public class KnowledgeTag : BaseUserEntity
    {
        [Display(Name = "Tag Name")]
        public string TagName { get; private set; }

        public IEnumerable<KnowledgeTagRelation> KnowledgeTagRelations { get; private set; }

        public KnowledgeTag(string tagName, string userId)
        {
            TagName = tagName;
            UserId = userId;
        }

        public override void ChangeTrashState(bool isTrashItem = false)
        {
            base.ChangeTrashState(isTrashItem);
            Events.Add(new TrashStateChanged<KnowledgeTag>(this));
        }
    }
}
