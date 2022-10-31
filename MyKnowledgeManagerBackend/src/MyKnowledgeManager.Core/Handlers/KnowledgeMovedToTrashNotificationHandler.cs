using MediatR;

namespace MyKnowledgeManager.Core.Handlers
{
    /// <summary>
    /// This class is a handler for <see cref="TrashStateChanged{Knowledge}"/> event.
    /// </summary>
    public class KnowledgeMovedToTrashNotificationHandler : INotificationHandler<TrashStateChanged<Knowledge>>
    {
        private readonly IKnowledgeTagRelationService _knowledgeTagRelationService;

        public KnowledgeMovedToTrashNotificationHandler(IKnowledgeTagRelationService knowledgeTagRelationService)
        {
            _knowledgeTagRelationService = knowledgeTagRelationService;
        }

        public async Task Handle(TrashStateChanged<Knowledge> notification, CancellationToken cancellationToken)
        {
            // Getting all child relations between Knowledge and KnowledgeTag
            List<KnowledgeTagRelation> knowledgeTagRelations = (List<KnowledgeTagRelation>)await _knowledgeTagRelationService.GetKnowledgeTagRelationsByKnowledgeIdAsync(notification.Entity.Id);

            // If we don't have any relations, we have to do nothing.
            if (knowledgeTagRelations is null || knowledgeTagRelations.Count is 0) return;

            // Checking IsTrashItem property to detect whether the item is moved to the trash recently or moved out.
            if (notification.Entity.IsTrashItem)
            {
                // Moving all children to the trash, because the Knowledge moved to the trash.
                knowledgeTagRelations.ForEach(x => x.ChangeTrashState(true));
            }
            else
            {
                // Moving all children out of the trash because the Knowledge moved out of the trash.
                knowledgeTagRelations.ForEach(x => x.ChangeTrashState());
            }

            // Updating all items in the database.
            await _knowledgeTagRelationService.UpdateRangeKnowledgeTagRelationAsync(knowledgeTagRelations);
        }
    }
}
