using MyKnowledgeManager.Core.Entities;

namespace MyKnowledgeManager.UnitTest.Builders
{
    public class ApplicationUserBuilder
    {
        private ApplicationUser _applicationUser;

        public ApplicationUserBuilder WithDefaultValues()
        {
            _applicationUser = new ApplicationUser("cba92d96-e0c0-4ffc-8e2c-d5e6789bc9dc");

            return this;
        }

        public ApplicationUser Build() => _applicationUser ?? WithDefaultValues().Build();
    }
}
