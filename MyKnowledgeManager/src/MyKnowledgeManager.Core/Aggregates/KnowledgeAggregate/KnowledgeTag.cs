namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate
{
    public class KnowledgeTag : BaseEntity
    {
        [Display(Name = "Tag Name")]
        public string TagName { get; private set; } = string.Empty;

        [Display(Name = "Knowledge")]
        public string KnowledgeId { get; private set; } = string.Empty;

        public Knowledge Knowledge { get; private set; } = null;

        public KnowledgeTag(string tagName, string knowledgeId, Knowledge knowledge)
        {
            TagName = tagName;
            KnowledgeId = knowledgeId;
            Knowledge = knowledge;
        }
    }
}
