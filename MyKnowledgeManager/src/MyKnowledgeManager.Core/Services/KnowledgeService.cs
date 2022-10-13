using Ardalis.GuardClauses;
using Ardalis.Result;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Services
{
    /// <summary>
    /// This class is used as an implementation of <see cref="IKnowledgeService"/> interface.
    /// </summary>
    public class KnowledgeService : IKnowledgeService
    {
        private readonly IRepository<Knowledge> _repository;

        public KnowledgeService(IRepository<Knowledge> repository)
        {
            _repository = repository;
        }

        public async Task<Result<Knowledge>> AddKnowledgeAsync(Knowledge knowledge)
        {
            Guard.Against.Null(knowledge, nameof(knowledge));

            return await _repository.AddAsync(knowledge);
        }

        public async Task<Result<bool>> RemoveKnowledgeAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            Knowledge knowledge = await _repository.GetByIdAsync(id);

            if (knowledge is not null)
            {
                try
                {
                    await _repository.DeleteAsync(knowledge);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
        
        public async Task<Result<Knowledge>> GetKnowledgeByIdAsync(string id, bool includeTags = false)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            Knowledge knowledge = await _repository.FirstOrDefaultAsync(includeTags ? new KnowledgeByIdWithTagsSpec(id) : new KnowledgeByIdSpec(id));

            return knowledge;
        }

        public async Task<Result<List<Knowledge>>> GetKnowledgesAsync(bool includeTags = false)
        {
            if (includeTags)
            {
                return await _repository.ListAsync(new KnowledgesWithTagsSpec());
            }
            else
            {
                return await _repository.ListAsync();
            }
        }

        public async Task<Result<Knowledge>> UpdateKnowledgeAsync(Knowledge knowledge)
        {
            Guard.Against.Null(knowledge);

            try
            {
                await _repository.UpdateAsync(knowledge);
            }
            catch (Exception)
            {
                return null;
            }

            return knowledge;
        }
    }
}
