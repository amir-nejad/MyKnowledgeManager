using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgesSpec : Specification<Entities.Knowledge>
    {
        public KnowledgesSpec()
        {
            Query
                .Where(x => !x.IsTrashItem);
        }
    }
}
