using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagRelationsByKnowledgeIdSpec : Specification<KnowledgeTagRelation>
    {
        public KnowledgeTagRelationsByKnowledgeIdSpec(string knowledgeId)
        {
            Query
                .Where(x => x.KnowledgeId == knowledgeId)
                .AsNoTracking();
        }
    }
}
