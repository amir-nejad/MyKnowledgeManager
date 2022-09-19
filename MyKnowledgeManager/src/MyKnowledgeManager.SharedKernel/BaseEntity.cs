using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.SharedKernel
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public List<BaseDomainEvent> Events { get; set; } = new List<BaseDomainEvent>();
    }
}
