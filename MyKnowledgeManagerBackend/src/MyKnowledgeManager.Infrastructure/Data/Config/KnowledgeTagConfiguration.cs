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
                .Property(x => x.Id)
                .IsRequired();

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.TagName)
                .IsRequired();

            builder
                .Property(p => p.UserId)
                .IsRequired();

            builder
                .HasIndex(propertyNames: new string[] { "TagName", "UserId" },name: "IX_TagNameAndUserId")
                .IsUnique();

            builder
                .HasOne(p => p.ApplicationUser)
                .WithMany(x => x.KnowledgeTags)
                .HasForeignKey(p => p.UserId);
        }
    }
}
