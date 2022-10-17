using Ardalis.GuardClauses;
using Ardalis.Result;
using MyKnowledgeManager.SharedKernel.Interfaces;

namespace MyKnowledgeManager.Core.Services
{
    public class TrashManager<T> : ITrashManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private const string SaveErrorMessage = "Operation Failed.";
        private const string NotFoundErrorMessage = "Internal error. Item not found.";

        public TrashManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Result> DeleteTrashItemAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            var item = await _repository.GetByIdAsync(id);

            if (item == null || !item.IsTrashItem) return Result.Error(NotFoundErrorMessage);

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

        public async Task<Result> DeleteTrashItemsAsync()
        {
            var items = await _repository.ListAsync(new TrashItemsSpec<T>());

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

        public async Task<Result<IEnumerable<T>>> GetTrashItemsAsync()
        {
            return await _repository.ListAsync(new TrashItemsSpec<T>());
        }

        public async Task<Result> RestoreTrashItemAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            T item = await _repository.GetByIdAsync(id);

            if(item == null || !item.IsTrashItem) return Result.Error(NotFoundErrorMessage);

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

        public async Task<Result> RestoreTrashItemsAsync()
        {
            List<T> items = await _repository.ListAsync(new TrashItemsSpec<T>());

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

        public async Task<Result> MoveItemToTrashAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            T item = await _repository.GetByIdAsync(id);

            if (item == null) return Result.Error(NotFoundErrorMessage);

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
