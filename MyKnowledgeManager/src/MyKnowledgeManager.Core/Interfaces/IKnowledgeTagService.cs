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
        /// This function is used for getting a <see cref="KnowledgeTag"/> object from the database.
        /// </summary>
        /// <param name="name">The name of the target object for retrieving.</param>
        /// <param name="includeKnowledges">Identify using Include() for tags or not.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTag"/> when operation succeeded.
        /// </returns>
        Task<Result<KnowledgeTag>> GetKnowledgeTagByNameAsync(string name, string userId, bool includeKnowledges = false);

        /// <summary>
        /// This function is used for getting a list of <see cref="KnowledgeTag"/> objects from the database.
        /// </summary>
        /// <param name="includeKnowledges">Identify using Include() for tags or not.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="List{KnowledgeTag}"/> when operation succeeded.
        /// </returns>
        Task<Result<IEnumerable<KnowledgeTag>>> GetKnowledgeTagsAsync(string userId, bool includeKnowledges = false);



        /// <summary>
        /// This function is used for creating a <see cref="KnowledgeTag"/> object.
        /// </summary>
        /// <param name="knowledgeTag">Target <see cref="KnowledgeTag"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTag"/> when is created successfully in the database.
        /// </returns>
        Task<Result<KnowledgeTag>> AddKnowledgeTagAsync(KnowledgeTag knowledgeTag);

        /// <summary>
        /// This function is used for creating a list of <see cref="KnowledgeTag"/> objects in the database.
        /// </summary>
        /// <param name="knowledgeTags">Target <see cref="IEnumerable{KnowledgeTag}"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="KnowledgeTag"/> when is created successfully in the database.
        /// </returns>
        Task<IEnumerable<KnowledgeTag>> AddRangeKnowledgeTagAsync(IEnumerable<KnowledgeTag> knowledgeTags);



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
        /// This function is used for removing a <see cref="KnowledgeTag"/> object.
        /// </summary>
        /// <param name="id">The id of the target object for deleting.</param>
        /// <returns>
        /// True <see cref="bool"/> response when is removed successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> RemoveKnowledgeTagAsync(string id, string userId);

        /// <summary>
        /// This function is used for removing a range of <see cref="KnowledgeTag"/> objects from the database.
        /// </summary>
        /// <param name="knowledgeTags"></param>
        /// <returns>
        /// True <see cref="bool"/> response when is removed successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> RemoveRangeTagsAsync(IEnumerable<KnowledgeTag> knowledgeTags, string userId);
    }
}
