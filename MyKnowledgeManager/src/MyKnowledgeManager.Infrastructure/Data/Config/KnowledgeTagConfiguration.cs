using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyKnowledgeManager.Core.Entities;

namespace MyKnowledgeManager.Infrastructure.Data.Config
{
    public class KnowledgeTagConfiguration : IEntityTypeConfiguration<KnowledgeTag>
    {
        public void Configure(EntityTypeBuilder<KnowledgeTag> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(x => x.TagName)
                .IsRequired();
        }
    }
}
