using MyKnowledgeManager.Core.Entities;

namespace MyKnowledgeManager.IntegrationTest.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddApplicationUserAndSetsId()
        {
            var repository = GetRepository<ApplicationUser>();

            ApplicationUser testUser = new ApplicationUserBuilder().Build();

            await repository.AddAsync(testUser);

            var addedUser = (await repository.ListAsync()).FirstOrDefault();

            Assert.True(addedUser?.Id != null);
            Assert.True(addedUser?.Id == "cba92d96-e0c0-4ffc-8e2c-d5e6789bc9dc");
        }

        [Fact]
        public async Task AddKnowledgeAndSetsId()
        {
            var repository = GetRepository<Knowledge>();

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
