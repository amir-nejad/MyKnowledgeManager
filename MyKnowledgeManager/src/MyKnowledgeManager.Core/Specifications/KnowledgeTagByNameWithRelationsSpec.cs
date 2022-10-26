using Ardalis.Specification;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagByNameWithRelationsSpec : Specification<KnowledgeTag>, ISingleResultSpecification<KnowledgeTag>
    {
        public KnowledgeTagByNameWithRelationsSpec(string tagName)
        {
            Query
                .Where(x => x.TagName.ToLower() == tagName.ToLower())
                .AsNoTracking()
                .Include(x => x.KnowledgeTagRelations);
        }
    }
}
