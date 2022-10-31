using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class TrashItemsSpec<T> : Specification<T> where T : BaseUserEntity
    {
        public TrashItemsSpec(string userId = null)
        {
            Query
                .Where(x => x.IsTrashItem && x.UserId == userId)
                .AsNoTracking();
        }
    }
}
