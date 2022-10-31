using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgesSpec : Specification<Knowledge>
    {
        public KnowledgesSpec(string userId = null)
        {
            Query
                .Where(x => !x.IsTrashItem && x.UserId == userId)
                .AsNoTracking();
        }
    }
}
