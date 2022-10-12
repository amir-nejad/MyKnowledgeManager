using Ardalis.GuardClauses;
using Ardalis.Result;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeTagManager.Core.Services
{
    /// <summary>
    /// This class is used as an implementation of <see cref="IKnowledgeTagService"/> interface.
    /// </summary>
    public class KnowledgeTagService : IKnowledgeTagService
    {
        private readonly IRepository<KnowledgeTag> _repository;

        public KnowledgeTagService(IRepository<KnowledgeTag> repository)
        {
            _repository = repository;
        }

        public async Task<Result<KnowledgeTag>> CreateKnowledgeTagAsync(KnowledgeTag knowledgeTag)
        {
            Guard.Against.Null(knowledgeTag, nameof(knowledgeTag));

            return await _repository.AddAsync(knowledgeTag);
        }

        public async Task<Result<bool>> DeleteKnowledgeTagAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            KnowledgeTag knowledgeTag = await _repository.GetByIdAsync(id);

            if (knowledgeTag is not null)
            {
                try
                {
                    await _repository.DeleteAsync(knowledgeTag);
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
        
        public async Task<Result<KnowledgeTag>> GetKnowledgeTagByIdAsync(string id, bool includeKnowledges = false)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            KnowledgeTag knowledgeTag = await _repository.FirstOrDefaultAsync(includeKnowledges ? new KnowledgeTagByIdWithRelationsSpec(id) : new KnowledgeTagByIdSpec(id));

            return knowledgeTag;
        }

        public async Task<Result<List<KnowledgeTag>>> GetKnowledgeTagsAsync(bool includeKnowledges = false)
        {
            return await _repository.ListAsync(specification: includeKnowledges ? new KnowledgeTagsWithRelationsSpec() : null);
        }

        public async Task<Result<KnowledgeTag>> UpdateKnowledgeTagAsync(KnowledgeTag knowledgeTag)
        {
            Guard.Against.Null(knowledgeTag);

            try
            {
                await _repository.UpdateAsync(knowledgeTag);
            }
            catch (Exception)
            {
                return null;
            }

            return knowledgeTag;
        }
    }
}
