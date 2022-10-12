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
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="List{KnowledgeTagRelation}"/> when operation succeeded.
        /// </returns>
        Task<Result<List<KnowledgeTagRelation>>> GetKnowledgeTagRelationsAsync();

        /// <summary>
        /// This function is used for creating a <see cref="KnowledgeTagRelation"/> object.
        /// </summary>
        /// <param name="knowledgeTagRelation">Target <see cref="KnowledgeTagRelation"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTagRelation"/> when is created successfully in the database.
        /// </returns>
        Task<Result<KnowledgeTagRelation>> CreateKnowledgeTagRelationAsync(KnowledgeTagRelation knowledgeTagRelation);

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
        /// This function is used for updating a <see cref="KnowledgeTagRelation"/> object.
        /// </summary>
        /// <param name="id">The id of the target object for deleting.</param>
        /// <returns>
        /// True <see cref="bool"/> response when is updated successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> DeleteKnowledgeTagRelationAsync(string id);
    }
}
