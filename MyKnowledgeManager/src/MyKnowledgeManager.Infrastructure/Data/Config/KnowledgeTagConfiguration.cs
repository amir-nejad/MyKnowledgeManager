using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyKnowledgeManager.Core.Aggregates.KnowledgeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.Infrastructure.Data.Config
{
    public class KnowledgeTagConfiguration : IEntityTypeConfiguration<KnowledgeTag>
    {
        public void Configure(EntityTypeBuilder<KnowledgeTag> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.TagName).IsRequired();
            builder
                .HasOne(p => p.Knowledge)
                .WithMany(k => k.KnowledgeTags)
                .HasForeignKey(p => p.KnowledgeId);
        }
    }
}
