using Microsoft.EntityFrameworkCore;
using MyKnowledgeManager.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.IntegrationTest.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
        {
            var repository = GetRepository();

            var knowledge = new KnowledgeBuilder().WithDefaultValues().Build();

            await repository.AddAsync(knowledge);

            await repository.DeleteAsync(knowledge);

            Assert.DoesNotContain(await repository.ListAsync(), k => k.Id == knowledge.Id);
        }
    }
}
