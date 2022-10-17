using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgesWithTagsSpec : Specification<Entities.Knowledge>
    {
        public KnowledgesWithTagsSpec()
        {
            Query
                .Where(x => !x.IsTrashItem)
                .Include(x => x.KnowledgeTagRelations);
        }
    }
}
