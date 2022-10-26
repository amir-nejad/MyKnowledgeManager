using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagByIdWithRelationsSpec : Specification<KnowledgeTag>, ISingleResultSpecification<KnowledgeTag>
    {
        public KnowledgeTagByIdWithRelationsSpec(string knowledgeTagId)
        {
            Query
                .Where(x => x.Id == knowledgeTagId)
                .AsNoTracking()
                .Include(x => x.KnowledgeTagRelations.Where(x => !x.IsTrashItem)).ThenInclude(x => x.Knowledge);
        }
    }
}
