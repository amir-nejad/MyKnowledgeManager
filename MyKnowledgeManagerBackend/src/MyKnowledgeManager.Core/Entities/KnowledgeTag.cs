
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

        public KnowledgeTag(string tagName, string userId, DateTime? createdDate = null, DateTime? updatedDate = null)
        {
            TagName = tagName;
            UserId = userId;
            CreatedDate = createdDate.HasValue ? createdDate.Value : CreatedDate;
            UpdatedDate = updatedDate.HasValue ? updatedDate.Value : UpdatedDate;
        }

        public override void ChangeTrashState(bool isTrashItem = false)
        {
            base.ChangeTrashState(isTrashItem);
            Events.Add(new TrashStateChanged<KnowledgeTag>(this));
        }
    }
}
