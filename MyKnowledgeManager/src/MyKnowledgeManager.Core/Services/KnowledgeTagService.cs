using Ardalis.GuardClauses;
using Ardalis.Result;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Services
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

        public async Task<Result<KnowledgeTag>> AddKnowledgeTagAsync(KnowledgeTag knowledgeTag)
        {
            Guard.Against.Null(knowledgeTag, nameof(knowledgeTag));

            return await _repository.AddAsync(knowledgeTag);
        }

        public async Task<IEnumerable<KnowledgeTag>> AddRangeKnowledgeTagAsync(IEnumerable<KnowledgeTag> knowledgeTags)
        {
            Guard.Against.Null(knowledgeTags, nameof(knowledgeTags));

            return await _repository.AddRangeAsync(knowledgeTags);
        }

        public async Task<Result<bool>> RemoveKnowledgeTagAsync(string id)
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

        public async Task<Result<KnowledgeTag>> GetKnowledgeTagByNameAsync(string name, bool includeKnowledges = false)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));

            KnowledgeTag knowledgeTag = await _repository.FirstOrDefaultAsync(includeKnowledges ? new KnowledgeTagByNameWithRelationsSpec(name) : new KnowledgeTagByNameSpec(name));

            return knowledgeTag;
        }

        public async Task<Result<IEnumerable<KnowledgeTag>>> GetKnowledgeTagsAsync(bool includeKnowledges = false)
        {
            if (includeKnowledges)
            {
                return await _repository.ListAsync(new KnowledgeTagsWithRelationsSpec());
            }
            else
            {
                return await _repository.ListAsync(new KnowledgeTagsSpec());
            }
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

        public async Task<Result<bool>> RemoveRangeTagsAsync(IEnumerable<KnowledgeTag> knowledgeTags)
        {
            Guard.Against.Null(knowledgeTags, nameof(knowledgeTags));

            try
            {
                await _repository.DeleteRangeAsync(knowledgeTags);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
