using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Specifications
{
    public class KnowledgesWithTagsSpec : Specification<Entities.Knowledge>
    {
        public KnowledgesWithTagsSpec()
        {
            Query
                .Include(x => x.KnowledgeTags);
        }
    }
}
