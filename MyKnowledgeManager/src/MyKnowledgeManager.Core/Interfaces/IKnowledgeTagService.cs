using Ardalis.Result;

namespace MyKnowledgeManager.Core.Interfaces
{
    /// <summary>
    /// This interface is used to declare related database functions for <see cref="KnowledgeTag"/>.
    /// </summary>
    public interface IKnowledgeTagService
    {

        /// <summary>
        /// This function is used for getting a <see cref="KnowledgeTag"/> object from the database.
        /// </summary>
        /// <param name="id">The id of the target object for retrieving.</param>
        /// <param name="includeKnowledges">Identify using Include() for tags or not.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTag"/> when operation succeeded.
        /// </returns>
        Task<Result<KnowledgeTag>> GetKnowledgeTagByIdAsync(string id, bool includeKnowledges = false);

        /// <summary>
        /// This function is used for getting a list of <see cref="KnowledgeTag"/> objects from the database.
        /// </summary>
        /// <param name="includeKnowledges">Identify using Include() for tags or not.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="List{KnowledgeTag}"/> when operation succeeded.
        /// </returns>
        Task<Result<List<KnowledgeTag>>> GetKnowledgeTagsAsync(bool includeKnowledges = false);

        /// <summary>
        /// This function is used for creating a <see cref="KnowledgeTag"/> object.
        /// </summary>
        /// <param name="knowledgeTag">Target <see cref="KnowledgeTag"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTag"/> when is created successfully in the database.
        /// </returns>
        Task<Result<KnowledgeTag>> CreateKnowledgeTagAsync(KnowledgeTag knowledgeTag);

        /// <summary>
        /// This function is used for updating a <see cref="KnowledgeTag"/> object.
        /// </summary>
        /// <param name="knowledgeTag">Target <see cref="KnowledgeTag"/> object for update.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTag"/> when is updated successfully in the database.
        /// </returns>
        Task<Result<KnowledgeTag>> UpdateKnowledgeTagAsync(KnowledgeTag knowledgeTag);

        /// <summary>
        /// This function is used for updating a <see cref="KnowledgeTag"/> object.
        /// </summary>
        /// <param name="id">The id of the target object for deleting.</param>
        /// <returns>
        /// True <see cref="bool"/> response when is updated successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> DeleteKnowledgeTagAsync(string id);
    }
}
