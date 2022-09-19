using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate
{
    public class KnowledgeTag : BaseEntity
    {
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }


    }
}
