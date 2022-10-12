using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagByIdSpec : Specification<KnowledgeTag>, ISingleResultSpecification<KnowledgeTag>
    {
        public KnowledgeTagByIdSpec(string knowledgeTagId)
        {
            Query
                .Where(x => x.Id == knowledgeTagId);
        }
    }
}
