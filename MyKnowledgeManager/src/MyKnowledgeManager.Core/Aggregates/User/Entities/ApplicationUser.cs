using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;

namespace MyKnowledgeManager.Core.Aggregates.User.Entities
{
    /// <summary>
    /// This class is used for "ApplicationUsers" database table.
    /// </summary>
    public class ApplicationUser : BaseEntity
    {
        public IList<Knowledge.Entities.Knowledge> Knowledges { get; set; }
    }
}
