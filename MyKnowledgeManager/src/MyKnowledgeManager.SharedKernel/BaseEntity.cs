﻿namespace MyKnowledgeManager.SharedKernel
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

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}