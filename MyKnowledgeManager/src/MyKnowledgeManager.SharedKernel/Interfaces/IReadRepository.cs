using Ardalis.Specification;

namespace MyKnowledgeManager.SharedKernel.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
