using MyKnowledgeManager.Core.Entities;

namespace MyKnowledgeManager.IntegrationTest.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesKnowledgeAfterAddingIt()
        {
            var repository = GetRepository<Knowledge>();

            var knowledge = new KnowledgeBuilder().WithDefaultValues().Build();

            await repository.AddAsync(knowledge);

            await repository.DeleteAsync(knowledge);

            Assert.DoesNotContain(await repository.ListAsync(), k => k.Id == knowledge.Id);
        }

        [Fact]
        public async Task DeleteUserAfterAddingIt()
        {
            var repository = GetRepository<ApplicationUser>();

            var user = new ApplicationUserBuilder().WithDefaultValues().Build();

            await repository.AddAsync(user);

            await repository.DeleteAsync(user);

            Assert.DoesNotContain(await repository.ListAsync(), k => k.Id == user.Id);
        }
    }
}
