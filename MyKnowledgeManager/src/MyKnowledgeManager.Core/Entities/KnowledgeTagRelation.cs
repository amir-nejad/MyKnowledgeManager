namespace MyKnowledgeManager.Core.Entities
{
    /// <summary>
    /// This class is used as the third class between Knowledge and KnowledgeTag for n-n relation implementation.
    /// </summary>
    public class KnowledgeTagRelation : BaseUserEntity
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

        // We don't need ApplicationUser and UserId properties but as our TrashManager needs UserId,
        // we have to destroy the automatic relationship between ApplicationUser and KnowledgeTagRelation classes.
        public new string ApplicationUser { get; }
        public new string UserId { get; }

        public override void UpdateUserId(string userId)
        {
            // We have not to do anything.
        }
    }
}
