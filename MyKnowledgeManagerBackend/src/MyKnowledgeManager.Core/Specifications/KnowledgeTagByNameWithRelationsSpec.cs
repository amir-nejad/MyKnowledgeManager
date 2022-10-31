using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagByNameWithRelationsSpec : Specification<KnowledgeTag>, ISingleResultSpecification<KnowledgeTag>
    {
        public KnowledgeTagByNameWithRelationsSpec(string tagName, string userId)
        {
            Query
                .Where(x => x.TagName.ToLower() == tagName.ToLower() && x.UserId == userId)
                .AsNoTracking()
                .Include(x => x.KnowledgeTagRelations);
        }
    }
}
