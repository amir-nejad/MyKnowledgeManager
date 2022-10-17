using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Specifications
{
    public class TrashItemsSpec<T> : Specification<T> where T : BaseEntity
    {
        public TrashItemsSpec()
        {
            Query
                .Where(x => x.IsTrashItem)
                .AsNoTracking();
        }
    }
}
