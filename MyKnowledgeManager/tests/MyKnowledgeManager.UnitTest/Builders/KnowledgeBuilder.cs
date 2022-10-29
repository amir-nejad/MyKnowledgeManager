using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.UnitTest.Builders
{
    public class KnowledgeBuilder
    {
        private Knowledge _knowledge;

        public KnowledgeBuilder WithDefaultValues()
        {
            _knowledge = new Knowledge("Test Title", "Test Description", KnowledgeLevel.Beginner, KnowledgeImportance.Neutral, "cba92d96-e0c0-4ffc-8e2c-d5e6789bc9dc");

            return this;
        }

        public Knowledge Build() => _knowledge ?? WithDefaultValues().Build();
    }
}
