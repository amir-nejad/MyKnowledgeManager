namespace MyKnowledgeManager.Core.Entities
{
    /// <summary>
    /// This class is used for "ApplicationUsers" database table.
    /// </summary>
    public class ApplicationUser : BaseEntity
    {
        public ApplicationUser(string id)
        {
            Id = id;
        }

        public IList<Knowledge> Knowledges { get; set; }

        public IList<KnowledgeTag> KnowledgeTags { get; set; }

        public IList<KnowledgeTagRelation> KnowledgeTagRelations { get; set; }
    }
}
