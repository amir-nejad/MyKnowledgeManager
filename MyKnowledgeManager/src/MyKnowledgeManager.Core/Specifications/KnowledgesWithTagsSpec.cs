using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgesWithTagsSpec : Specification<Entities.Knowledge>
    {
        public KnowledgesWithTagsSpec()
        {
            Query
                .Include(x => x.KnowledgeTagRelations);
        }
    }
}
