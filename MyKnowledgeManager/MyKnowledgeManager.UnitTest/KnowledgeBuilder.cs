using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.UnitTest
{
    public class KnowledgeBuilder
    {
        private Knowledge _knowledge;

        public KnowledgeBuilder WithDefaultValues()
        {
            _knowledge = new Knowledge("Test Title", "Test Description", KnowledgeLevel.Beginner, KnowledgeImportance.Neutral);

            return this;
        }

        public Knowledge Build() => _knowledge ?? WithDefaultValues().Build();
    }
}
