using Ardalis.Result;

namespace MyKnowledgeManager.Core.Interfaces
{
    /// <summary>
    /// This interface is used to declare related database functions for <see cref="KnowledgeTagRelation"/>.
    /// </summary>
    public interface IKnowledgeTagRelationService
    {

        /// <summary>
        /// This function is used for getting a <see cref="KnowledgeTagRelation"/> object from the database.
        /// </summary>
        /// <param name="id">The id of the target object for retrieving.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTagRelation"/> when operation succeeded.
        /// </returns>
        Task<Result<KnowledgeTagRelation>> GetKnowledgeTagRelationByIdAsync(string id);

        /// <summary>
        /// This function is used for getting a list of <see cref="KnowledgeTagRelation"/> objects from the database.
        /// </summary>
        /// <param name="knowledgeId">The id of the target knowledge for retrieving objects.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="IEnumerable{KnowledgeTagRelation}"/> when operation succeeded.
        /// </returns>
        Task<Result<IEnumerable<KnowledgeTagRelation>>> GetKnowledgeTagRelationsByKnowledgeIdAsync(string knowledgeId);

        /// <summary>
        /// This function is used for getting a list of <see cref="KnowledgeTagRelation"/> objects from the database.
        /// </summary>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="IEnumerable{KnowledgeTagRelation}"/> when operation succeeded.
        /// </returns>
        Task<Result<IEnumerable<KnowledgeTagRelation>>> GetKnowledgeTagRelationsAsync();

        /// <summary>
        /// This function is used for creating a <see cref="KnowledgeTagRelation"/> object.
        /// </summary>
        /// <param name="knowledgeTagRelation">Target <see cref="KnowledgeTagRelation"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTagRelation"/> when is created successfully in the database.
        /// </returns>
        Task<Result<KnowledgeTagRelation>> AddKnowledgeTagRelationAsync(KnowledgeTagRelation knowledgeTagRelation);

        /// <summary>
        /// This function is used for creating a list <see cref="KnowledgeTagRelation"/> object to the database.
        /// </summary>
        /// <param name="knowledgeTagRelations">Target <see cref="IEnumerable{KnowledgeTagRelation}"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="IEnumerable{KnowledgeTagRelation}"/> when is created successfully in the database.
        /// </returns>
        Task<IEnumerable<KnowledgeTagRelation>> AddRangeKnowledgeTagRelationAsync(IEnumerable<KnowledgeTagRelation> knowledgeTagRelations);

        /// <summary>
        /// This function is used for updating a <see cref="KnowledgeTagRelation"/> object.
        /// </summary>
        /// <param name="knowledgeTagRelation">Target <see cref="KnowledgeTagRelation"/> object for update.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTagRelation"/> when is updated successfully in the database.
        /// </returns>
        Task<Result<KnowledgeTagRelation>> UpdateKnowledgeTagRelationAsync(KnowledgeTagRelation knowledgeTagRelation);

        /// <summary>
        /// This function is used for removing a <see cref="KnowledgeTagRelation"/> object.
        /// </summary>
        /// <param name="id">The id of the target object for deleting.</param>
        /// <returns>
        /// True <see cref="bool"/> response when is removed successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> RemoveKnowledgeTagRelationAsync(string id);

        /// <summary>
        /// This function is used for removing a range of <see cref="KnowledgeTagRelation"/> objects from the database.
        /// </summary>
        /// <param name="knowledgeTagRelations"></param>
        /// <returns>
        /// True <see cref="bool"/> response when is removed successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> RemoveRangeTagsAsync(IEnumerable<KnowledgeTagRelation> knowledgeTagRelations);
    }
}
