namespace MyKnowledgeManager.Core.Events
{
    public class TrashStateChanged<T> : BaseDomainEvent where T : BaseEntity
    {
        public T Entity { get; set; }

        public TrashStateChanged(T entity)
        {
            Entity = entity;
        }
    }
}
