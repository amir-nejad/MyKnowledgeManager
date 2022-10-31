using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeByIdSpec : Specification<Knowledge>, ISingleResultSpecification<Entities.Knowledge>
    {
        public KnowledgeByIdSpec(string knowledgeId)
        {
            Query.
                Where(x => x.Id == knowledgeId)
                .AsNoTracking();
        }
    }
}
