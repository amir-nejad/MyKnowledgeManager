using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyKnowledgeManager.Core.Entities;

namespace MyKnowledgeManager.Infrastructure.Data.Config
{
    public class KnowledgeTagRelationConfiguration : IEntityTypeConfiguration<KnowledgeTagRelation>
    {
        public void Configure(EntityTypeBuilder<KnowledgeTagRelation> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.KnowledgeId)
                .IsRequired();

            builder
                .Property(p => p.KnowledgeTagId)
                .IsRequired();

            builder
                .HasOne(p => p.Knowledge)
                .WithMany(x => x.KnowledgeTagRelations)
                .HasForeignKey(p => p.KnowledgeId);

            builder
                .HasOne(p => p.KnowledgeTag)
                .WithMany(x => x.KnowledgeTagRelations)
                .HasForeignKey(p => p.KnowledgeTagId);
        }
    }
}
