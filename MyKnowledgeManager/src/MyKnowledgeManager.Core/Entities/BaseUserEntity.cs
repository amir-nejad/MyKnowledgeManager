using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Entities
{
    public class BaseUserEntity : BaseEntity
    {
        public string UserId { get; protected set; }

        public virtual ApplicationUser ApplicationUser { get; protected set; }

        public virtual void UpdateUserId(string userId)
        {
            UserId = userId;
        }
    }
}
