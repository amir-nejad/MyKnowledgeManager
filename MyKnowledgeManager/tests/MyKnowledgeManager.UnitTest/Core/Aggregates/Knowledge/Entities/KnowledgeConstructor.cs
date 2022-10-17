using MyKnowledgeManager.Core.Enums;
using TestKnowledge = MyKnowledgeManager.Core.Entities.Knowledge;

namespace MyKnowledgeManager.UnitTest.Core.Aggregates.Knowledge.Entities
{
    public class KnowledgeConstructor
    {
        private string _testTitle = "Test Title";
        private string _testDescription = "Test Description";
        private KnowledgeLevel _testKnowledgeLevel = KnowledgeLevel.Beginner;
        private KnowledgeImportance _testKnowledgeImportance = KnowledgeImportance.Important;
        private TestKnowledge _testKnowledge;

        private TestKnowledge CreateTestKnowledge()
        {
            return new TestKnowledge(_testTitle, _testDescription, _testKnowledgeLevel, _testKnowledgeImportance);
        }

        [Fact]
        public void InitializesTitle()
        {
            _testKnowledge = this.CreateTestKnowledge();

            Assert.Equal(_testTitle, _testKnowledge.Title);
        }

        [Fact]
        public void InitializesDescription()
        {
            _testKnowledge = this.CreateTestKnowledge();

            Assert.Equal(_testDescription, _testKnowledge.Description);
        }

        [Fact]
        public void InitializesKnowledgeLevel()
        {
            _testKnowledge = this.CreateTestKnowledge();

            Assert.Equal(_testKnowledgeLevel, _testKnowledge.KnowledgeLevel);
        }

        [Fact]
        public void InitializesKnowledgeImportance()
        {
            _testKnowledge = this.CreateTestKnowledge();

            Assert.Equal(_testKnowledgeImportance, _testKnowledge.KnowledgeImportance);
        }

        [Fact]
        public void InitializesKnowledgeTagRelationsEmptyList()
        {
            _testKnowledge = this.CreateTestKnowledge();

            Assert.NotNull(_testKnowledge.KnowledgeTagRelations);
        }
    }
}
