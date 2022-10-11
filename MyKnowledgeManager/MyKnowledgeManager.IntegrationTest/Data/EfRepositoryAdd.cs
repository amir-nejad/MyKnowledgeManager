using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using MyKnowledgeManager.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.IntegrationTest.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddKnowledgeAndSetsId()
        {
            var repository = GetRepository();

            Knowledge testKnowledge = new KnowledgeBuilder().Build();

            await repository.AddAsync(testKnowledge);

            var addedKnowledge = (await repository.ListAsync()).FirstOrDefault();

            Assert.Equal(testKnowledge.Title, addedKnowledge?.Title);
            Assert.Equal(testKnowledge.Description, addedKnowledge?.Description);
            Assert.Equal(testKnowledge.KnowledgeLevel, addedKnowledge?.KnowledgeLevel);
            Assert.Equal(testKnowledge.KnowledgeImportance, addedKnowledge?.KnowledgeImportance);
            Assert.True(addedKnowledge?.Id != null);
        }
    }
}
