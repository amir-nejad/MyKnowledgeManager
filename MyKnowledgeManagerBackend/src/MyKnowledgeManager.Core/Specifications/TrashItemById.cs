using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class TrashItemById<T> : Specification<T>, ISingleResultSpecification<T> where T : BaseEntity
    {
        public TrashItemById(string id)
        {
            Query
                .Where(x => x.Id == id && x.IsTrashItem)
                .AsNoTracking();
        }
    }
}
