using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgesWithTagsSpec : Specification<Knowledge>
    {
        public KnowledgesWithTagsSpec(string userId = null)
        {
            Query
                .Where(x => !x.IsTrashItem && x.UserId == userId)
                .AsNoTracking()
                .Include(x => x.KnowledgeTagRelations).ThenInclude(x => x.KnowledgeTag);
        }
    }
}
