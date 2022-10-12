using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagRelationsSpec : Specification<KnowledgeTagRelation>, ISingleResultSpecification<KnowledgeTagRelation>
    {
        public KnowledgeTagRelationsSpec()
        {
            Query
                .Include(x => x.KnowledgeTag)
                .Include(x => x.Knowledge)
                .AsNoTracking();
        }
    }
}
