using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagRelationByIdSpec : Specification<KnowledgeTagRelation>, ISingleResultSpecification<KnowledgeTagRelation>
    {
        public KnowledgeTagRelationByIdSpec(string id)
        {
            Query
                .Where(x => x.Id == id)
                .Include(x => x.KnowledgeTag)
                .Include(x => x.Knowledge)
                .AsNoTracking();
        }
    }
}
