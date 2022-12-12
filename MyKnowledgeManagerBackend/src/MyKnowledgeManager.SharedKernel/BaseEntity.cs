using System.ComponentModel.DataAnnotations.Schema;

namespace MyKnowledgeManager.SharedKernel
{
    /// <summary>
    /// This class is used as a base class for all entities. Mutual properties between all entities are placed here.
    /// </summary>
    public abstract class BaseEntity
    {
        public string Id { get; protected set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; protected set; } = DateTime.UtcNow;

        public bool IsTrashItem { get; protected set; } = false;

        public DateTime? MovedToTrashDateTime { get; protected set; }

        public string RemoverUserId { get; protected set; }

        public List<BaseDomainEvent> Events = new();

        public virtual void ChangeTrashState(bool isTrashItem = false)
        {
            IsTrashItem = isTrashItem;
        }
    }
}