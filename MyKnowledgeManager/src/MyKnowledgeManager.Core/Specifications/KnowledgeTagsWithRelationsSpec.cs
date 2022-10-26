using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagsWithRelationsSpec : Specification<KnowledgeTag>
    {
        public KnowledgeTagsWithRelationsSpec()
        {
            Query
                .Include(x => x.KnowledgeTagRelations.Where(x => !x.IsTrashItem)).ThenInclude(x => x.Knowledge)
                .AsNoTracking();
        }
    }
}
