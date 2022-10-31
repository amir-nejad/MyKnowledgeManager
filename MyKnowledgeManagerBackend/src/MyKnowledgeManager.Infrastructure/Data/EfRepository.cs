using Ardalis.Specification.EntityFrameworkCore;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
