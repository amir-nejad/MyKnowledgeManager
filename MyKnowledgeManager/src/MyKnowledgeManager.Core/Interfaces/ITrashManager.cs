using Ardalis.Result;

namespace MyKnowledgeManager.Core.Interfaces
{
    public interface ITrashManager<T> where T : class
    {
        /// <summary>
        /// This function is used for getting a list of trash items of type <see cref="T"/>.
        /// </summary>
        /// <returns></returns>
        Task<Result<IEnumerable<T>>> GetTrashItemsAsync();

        /// <summary>
        /// This function is used for deleting a trash item forever.
        /// </summary>
        /// <param name="id">The id of the target item.</param>
        /// <returns></returns>
        Task<Result> DeleteTrashItemAsync(string id);

        /// <summary>
        /// This function is used for deleting a list of trash items.
        /// </summary>
        /// <returns></returns>
        Task<Result> DeleteTrashItemsAsync();

        /// <summary>
        /// This function is used for restoring one item from the trash.
        /// </summary>
        /// <param name="id">The id of the target item.</param>
        /// <returns></returns>
        Task<Result> RestoreTrashItemAsync(string id);

        /// <summary>
        /// This function is used for restoring all items from the trash.
        /// </summary>
        /// <returns></returns>
        Task<Result> RestoreTrashItemsAsync();

        /// <summary>
        /// This function is used for moving one item into the trash.
        /// </summary>
        /// <param name="id">The id of the target object.</param>
        /// <returns></returns>
        Task<Result> MoveItemToTrashAsync(string id);
    }
}
