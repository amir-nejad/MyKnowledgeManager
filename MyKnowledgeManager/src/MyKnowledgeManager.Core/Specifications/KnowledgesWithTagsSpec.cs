using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgesWithTagsSpec : Specification<Knowledge>
    {
        public KnowledgesWithTagsSpec()
        {
            Query
                .Where(x => !x.IsTrashItem)
                .AsNoTracking()
                .Include(x => x.KnowledgeTagRelations).ThenInclude(x => x.KnowledgeTag);
        }
    }
}
