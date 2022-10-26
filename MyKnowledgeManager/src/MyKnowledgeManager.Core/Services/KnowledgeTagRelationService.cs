using Ardalis.GuardClauses;
using Ardalis.Result;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Services
{
    /// <summary>
    /// This class is used as an implementation of <see cref="IKnowledgeTagRelationService"/> interface.
    /// </summary>
    public class KnowledgeTagRelationService : IKnowledgeTagRelationService
    {
        private readonly IRepository<KnowledgeTagRelation> _repository;

        public KnowledgeTagRelationService(IRepository<KnowledgeTagRelation> repository)
        {
            _repository = repository;
        }

        public async Task<Result<KnowledgeTagRelation>> AddKnowledgeTagRelationAsync(KnowledgeTagRelation knowledgeTagRelation)
        {
            Guard.Against.Null(knowledgeTagRelation, nameof(knowledgeTagRelation));

            return await _repository.AddAsync(knowledgeTagRelation);
        }

        public async Task<Result<IEnumerable<KnowledgeTagRelation>>> AddRangeKnowledgeTagRelationAsync(IEnumerable<KnowledgeTagRelation> knowledgeTagRelations)
        {
            Guard.Against.Null(knowledgeTagRelations, nameof(knowledgeTagRelations));

            knowledgeTagRelations = await _repository.AddRangeAsync(knowledgeTagRelations);

            return knowledgeTagRelations.ToList();
        }

        public async Task<Result<bool>> RemoveKnowledgeTagRelationAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            KnowledgeTagRelation knowledgeTagRelation = await _repository.GetByIdAsync(id);

            if (knowledgeTagRelation is not null)
            {
                try
                {
                    await _repository.DeleteAsync(knowledgeTagRelation);
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
        
        public async Task<Result<KnowledgeTagRelation>> GetKnowledgeTagRelationByIdAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            KnowledgeTagRelation knowledgeTagRelation = await _repository.FirstOrDefaultAsync(new KnowledgeTagRelationByIdSpec(id));

            return knowledgeTagRelation;
        }

        public async Task<Result<IEnumerable<KnowledgeTagRelation>>> GetKnowledgeTagRelationsAsync()
        {
            return await _repository.ListAsync(new KnowledgeTagRelationsSpec());
        }

        public async Task<Result<KnowledgeTagRelation>> UpdateKnowledgeTagRelationAsync(KnowledgeTagRelation knowledgeTagRelation)
        {
            Guard.Against.Null(knowledgeTagRelation);

            try
            {
                await _repository.UpdateAsync(knowledgeTagRelation);
            }
            catch (Exception)
            {
                return null;
            }

            return knowledgeTagRelation;
        }

        public async Task<Result<IEnumerable<KnowledgeTagRelation>>> UpdateRangeKnowledgeTagRelationAsync(IEnumerable<KnowledgeTagRelation> knowledgeTagRelations)
        {
            Guard.Against.Null(knowledgeTagRelations);

            try
            {
                await _repository.UpdateRangeAsync(knowledgeTagRelations);
            }
            catch (Exception)
            {
                return null;
            }

            return knowledgeTagRelations.ToList();
        }

        public async Task<Result<bool>> RemoveRangeTagsAsync(IEnumerable<KnowledgeTagRelation> knowledgeTagRelations)
        {

            Guard.Against.Null(knowledgeTagRelations, nameof(knowledgeTagRelations));

            try
            {
                await _repository.DeleteRangeAsync(knowledgeTagRelations);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<Result<IEnumerable<KnowledgeTagRelation>>> GetKnowledgeTagRelationsByKnowledgeIdAsync(string knowledgeId)
        {
            Guard.Against.NullOrEmpty(knowledgeId, nameof(knowledgeId));

            return await _repository.ListAsync(new KnowledgeTagRelationsByKnowledgeIdSpec(knowledgeId));
        }
    }
}
