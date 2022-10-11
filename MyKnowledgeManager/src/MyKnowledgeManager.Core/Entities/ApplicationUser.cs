namespace MyKnowledgeManager.Core.Entities
{
    /// <summary>
    /// This class is used for "ApplicationUsers" database table.
    /// </summary>
    public class ApplicationUser : BaseEntity
    {
        public IList<Knowledge> Knowledges { get; set; }
    }
}
