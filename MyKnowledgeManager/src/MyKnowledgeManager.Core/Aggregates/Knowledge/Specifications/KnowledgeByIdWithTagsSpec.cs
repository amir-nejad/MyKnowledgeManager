using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Specifications
{
    public class KnowledgeByIdWithTagsSpec : Specification<Entities.Knowledge>, ISingleResultSpecification<Entities.Knowledge>
    {
        public KnowledgeByIdWithTagsSpec(string knowledgeId)
        {
            Query.
                Where(x => x.Id == knowledgeId)
                .Include(x => x.KnowledgeTags)
                .AsNoTracking();
        }
    }
}
