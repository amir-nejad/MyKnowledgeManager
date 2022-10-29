using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagRelationsSpec : Specification<KnowledgeTagRelation>
    {
        public KnowledgeTagRelationsSpec(string userId)
        {
            Query
                .Where(x => !x.IsTrashItem && x.UserId == userId)
                .Include(x => x.KnowledgeTag)
                .Include(x => x.Knowledge)
                .AsNoTrackingWithIdentityResolution();
        }
    }
}
