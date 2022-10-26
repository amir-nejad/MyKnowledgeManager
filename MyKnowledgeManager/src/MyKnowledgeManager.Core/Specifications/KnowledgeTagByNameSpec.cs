using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagByNameSpec : Specification<KnowledgeTag>, ISingleResultSpecification<KnowledgeTag>
    {
        public KnowledgeTagByNameSpec(string tagName)
        {
            Query
                .Where(x => x.TagName.ToLower() == tagName.ToLower())
                .AsNoTracking();
        }
    }
}
