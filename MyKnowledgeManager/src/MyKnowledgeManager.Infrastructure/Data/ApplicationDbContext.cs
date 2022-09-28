using MediatR;
using Microsoft.EntityFrameworkCore;
using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using MyKnowledgeManager.Core.Aggregates.User.Entities;
using MyKnowledgeManager.SharedKernel;
using System.Reflection;

namespace MyKnowledgeManager.Infrastructure.Data
{
    /// <summary>
    /// This class is used as the DbContext hub.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        private readonly IMediator? _mediator;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Knowledge> Knowledges => Set<Knowledge>();

        public DbSet<KnowledgeTag> KnowledgeTags => Set<KnowledgeTag>();

        public DbSet<KnowledgeTagRelation> KnowledgeTagsRelation => Set<KnowledgeTagRelation>();

        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Ignore events if no dispatcher provided
            if (_mediator == null) return result;

            // Dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(x => x.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();

                foreach (var @event in events)
                {
                    await _mediator.Publish(@event).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
