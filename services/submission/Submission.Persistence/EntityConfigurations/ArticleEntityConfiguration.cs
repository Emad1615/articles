using Blocks.EntityFramework;
using Blocks.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;

namespace Submission.Persistence.EntityConfigurations
{
    internal class ArticleEntityConfiguration : EntityTypeConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(265);
            builder.Property(a => a.Scope)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(a => a.Type).HasEnumConversion();
            builder.Property(s => s.Stage).HasEnumConversion();

            builder.HasOne(a => a.Journal)
                   .WithMany(x => x.Articles)
                   .HasForeignKey(x => x.JournalId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
