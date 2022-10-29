using Ardalis.GuardClauses;
using Ardalis.Result;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Services
{
    public class TrashManager<T> : ITrashManager<T> where T : BaseUserEntity
    {
        private readonly IRepository<T> _repository;
        private const string SaveErrorMessage = "Operation Failed.";
        private const string NotFoundErrorMessage = "Internal error. Item not found.";

        public TrashManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Result> DeleteTrashItemAsync(string id, string userId = null)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            if (userId is null) return Result.Unauthorized();

            var item = await _repository.GetByIdAsync(id);

            if (item == null || !item.IsTrashItem) return Result.NotFound(NotFoundErrorMessage);

            if (item.UserId != userId) return Result.Forbidden();

            try
            {
                await _repository.DeleteAsync(item);
            }
            catch (Exception)
            {
                Result.Error(SaveErrorMessage);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteTrashItemsAsync(string userId = null)
        {
            if (userId is null) return Result.Unauthorized();

            var items = await _repository.ListAsync(new TrashItemsSpec<T>(userId));

            if (items is null || items.Count is 0) return Result.Success();

            try
            {
                await _repository.DeleteRangeAsync(items);
            }
            catch (Exception)
            {
                return Result.Error(SaveErrorMessage);
            }

            return Result.Success();
        }

        public async Task<Result<IEnumerable<T>>> GetTrashItemsAsync(string userId = null)
        {
            if (userId is null) return Result.Unauthorized();

            return await _repository.ListAsync(new TrashItemsSpec<T>(userId));
        }

        public async Task<Result> RestoreTrashItemAsync(string id, string userId = null)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            if (userId is null) return Result.Unauthorized();

            T item = await _repository.GetByIdAsync(id);

            if (item == null || !item.IsTrashItem) return Result.NotFound(NotFoundErrorMessage);

            if (item.UserId != userId) return Result.Forbidden();

            item.ChangeTrashState(false);

            try
            {
                await _repository.UpdateAsync(item);
            }
            catch (Exception)
            {
                return Result.Error(SaveErrorMessage);
            }

            return Result.Success();
        }

        public async Task<Result> RestoreTrashItemsAsync(string userId = null)
        {
            if (userId is null) return Result.Unauthorized();

            List<T> items = await _repository.ListAsync(new TrashItemsSpec<T>(userId));

            if (items is null || items.Count is 0) return Result.Success();

            foreach (var item in items)
            {
                item.ChangeTrashState(false);
            }

            try
            {
                await _repository.UpdateRangeAsync(items);
            }
            catch (Exception)
            {
                return Result.Error(SaveErrorMessage);
            }

            return Result.Success();
        }

        public async Task<Result> MoveItemToTrashAsync(string id, string userId = null)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            if (userId is null) return Result.Unauthorized();

            T item = await _repository.GetByIdAsync(id);

            if (item == null) return Result.NotFound(NotFoundErrorMessage);

            if (item.UserId != userId) return Result.Forbidden();

            item.ChangeTrashState(true);

            try
            {
                await _repository.UpdateAsync(item);
            }
            catch (Exception)
            {
                return Result.Error(SaveErrorMessage);
            }

            return Result.Success();
        }
    }
}
