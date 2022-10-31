using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagsWithRelationsSpec : Specification<KnowledgeTag>
    {
        public KnowledgeTagsWithRelationsSpec(string userId)
        {
            Query
                .Where(x => !x.IsTrashItem && x.UserId == userId)
                .Include(x => x.KnowledgeTagRelations.Where(x => !x.IsTrashItem)).ThenInclude(x => x.Knowledge)
                .AsNoTracking();
        }
    }
}
