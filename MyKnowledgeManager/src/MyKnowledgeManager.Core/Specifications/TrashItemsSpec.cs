using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class TrashItemsSpec<T> : Specification<T> where T : BaseEntity
    {
        public TrashItemsSpec()
        {
            Query
                .Where(x => x.IsTrashItem)
                .AsNoTracking();
        }
    }
}
