using Microsoft.EntityFrameworkCore;
using MyKnowledgeManager.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.IntegrationTest.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            var repository = GetRepository();

            var knowledge = new KnowledgeBuilder().WithDefaultValues().Build();

            await repository.AddAsync(knowledge);

            // detach the item so we get a different instance
            _context.Entry(knowledge).State = EntityState.Detached;

            var addedKnowledge = await repository.GetByIdAsync(knowledge.Id);

            if (addedKnowledge is null)
            {
                Assert.NotNull(addedKnowledge);
                return;
            }

            Assert.NotSame(knowledge, addedKnowledge);

            string newTitle = "New Title";

            addedKnowledge.UpdateTitle(newTitle);

            await repository.UpdateAsync(addedKnowledge);

            var updatedKnowledge = await repository.GetByIdAsync(knowledge.Id);

            Assert.NotNull(updatedKnowledge);
            Assert.NotEqual(knowledge, updatedKnowledge);
            Assert.Equal(knowledge.Id, updatedKnowledge.Id);
            Assert.Equal(knowledge.KnowledgeImportance, updatedKnowledge.KnowledgeImportance);
        }
    }
}
