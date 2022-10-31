using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagRelationsSpec : Specification<KnowledgeTagRelation>
    {
        public KnowledgeTagRelationsSpec()
        {
            Query
                .Where(x => !x.IsTrashItem)
                .Include(x => x.KnowledgeTag)
                .Include(x => x.Knowledge)
                .AsNoTrackingWithIdentityResolution();
        }
    }
}
