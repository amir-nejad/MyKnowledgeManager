using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Specifications
{
    public class KnowledgeByIdSpec : Specification<Entities.Knowledge>, ISingleResultSpecification<Entities.Knowledge>
    {
        public KnowledgeByIdSpec(string knowledgeId)
        {
            Query.
                Where(x => x.Id == knowledgeId)
                .AsNoTracking();
        }
    }
}
