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
    public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
