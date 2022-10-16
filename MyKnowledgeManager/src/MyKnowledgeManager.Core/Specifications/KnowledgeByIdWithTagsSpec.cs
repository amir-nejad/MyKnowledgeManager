using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeByIdWithTagsSpec : Specification<Entities.Knowledge>, ISingleResultSpecification<Entities.Knowledge>
    {
        public KnowledgeByIdWithTagsSpec(string knowledgeId)
        {
            Query.
                Where(x => x.Id == knowledgeId)
                .AsNoTracking()
                .Include(x => x.KnowledgeTagRelations).ThenInclude(x => x.KnowledgeTag);
        }
    }
}
