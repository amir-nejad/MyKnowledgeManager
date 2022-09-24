using Ardalis.Result;
using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Core.Interfaces
{
    /// <summary>
    /// This interface is used to declare related database functions for <see cref="Knowledge"/>.
    /// </summary>
    public interface IKnowledgeService
    {

        /// <summary>
        /// This function is used for getting a <see cref="Knowledge"/> object from the database.
        /// </summary>
        /// <param name="id">The id of the target object for retrieving.</param>
        /// <param name="includeTags">Identify using Include() for tags or not.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="Knowledge"/> when operation succeeded.
        /// </returns>
        Task<Result<Knowledge>> GetKnowledgeByIdAsync(string id, bool includeTags = false);

        /// <summary>
        /// This function is used for getting a list of <see cref="Knowledge"/> objects from the database.
        /// </summary>
        /// <param name="includeTags">Identify using Include() for tags or not.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="List{Knowledge}"/> when operation succeeded.
        /// </returns>
        Task<Result<List<Knowledge>>> GetKnowledgesAsync(bool includeTags = false);

        /// <summary>
        /// This function is used for creating a <see cref="Knowledge"/> object.
        /// </summary>
        /// <param name="knowledge">Target <see cref="Knowledge"/> object for creation.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="Knowledge"/> when is created successfully in the database.
        /// </returns>
        Task<Result<Knowledge>> CreateKnowledgeAsync(Knowledge knowledge);

        /// <summary>
        /// This function is used for updating a <see cref="Knowledge"/> object.
        /// </summary>
        /// <param name="knowledge">Target <see cref="Knowledge"/> object for update.</param>
        /// <returns>
        /// Null when any errors occurred.
        /// <see cref="Knowledge"/> when is updated successfully in the database.
        /// </returns>
        Task<Result<Knowledge>> UpdateKnowledgeAsync(Knowledge knowledge);

        /// <summary>
        /// This function is used for updating a <see cref="Knowledge"/> object.
        /// </summary>
        /// <param name="id">The id of the target object for deleting.</param>
        /// <returns>
        /// True <see cref="bool"/> response when is updated successfully in the database.
        /// False <see cref="bool"/> when any errors occurred.
        /// </returns>
        Task<Result<bool>> DeleteKnowledgeAsync(string id);
    }
}
