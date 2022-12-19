using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyKnowledgeManager.Core.Entities;

namespace MyKnowledgeManager.Infrastructure.Data.Config
{
    public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder
                .Property(x => x.Id)
                .IsRequired();

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .IsRequired();

            builder
                .Property(p => p.UserId)
                .IsRequired();

            builder
                .HasOne(p => p.ApplicationUser)
                .WithMany(x => x.Knowledges)
                .HasForeignKey(p => p.UserId);
        }
    }
}
