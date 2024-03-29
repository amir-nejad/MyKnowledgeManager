﻿using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Specifications
{
    public class KnowledgeTagsSpec : Specification<KnowledgeTag>
    {
        public KnowledgeTagsSpec(string userId)
        {
            Query
                .Where(x => !x.IsTrashItem && x.UserId == userId)
                .AsNoTracking();
        }
    }
}
