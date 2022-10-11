namespace MyKnowledgeManager.Core.Entities
{
    /// <summary>
    /// This class is used as the third class between Knowledge and KnowledgeTag for n-n relation implementation.
    /// </summary>
    public class KnowledgeTagRelation : BaseEntity
    {
        public string KnowledgeId { get; private set; }

        public string KnowledgeTagId { get; private set; }

        public virtual Knowledge Knowledge { get; set; }

        public virtual KnowledgeTag KnowledgeTag { get; set; }

        public KnowledgeTagRelation(string knowledgeId, string knowledgeTagId)
        {
            KnowledgeId = knowledgeId;
            KnowledgeTagId = knowledgeTagId;
        }
    }
}
