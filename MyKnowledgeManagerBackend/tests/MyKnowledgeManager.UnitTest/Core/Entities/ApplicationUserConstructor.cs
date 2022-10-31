using TestUser = MyKnowledgeManager.Core.Entities.ApplicationUser;

namespace MyKnowledgeManager.UnitTest.Core.Entities
{
    public class ApplicationUserConstructor
    {
        private string _testApplicationUserId = "cba92d96-e0c0-4ffc-8e2c-d5e6789bc9dc";
        private TestUser _testUser;

        private TestUser CreateTestUser()
        {
            return new TestUser(_testApplicationUserId);
        }

        [Fact]
        public void InitializeUser()
        {
            _testUser = this.CreateTestUser();

            Assert.Equal(_testUser.Id, _testApplicationUserId);
        }
    }
}
