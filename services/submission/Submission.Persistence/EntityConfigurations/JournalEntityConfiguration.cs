using Blocks.EntityFramework.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;

namespace Submission.Persistence.EntityConfigurations
{
    internal class JournalEntityConfiguration : EntityTypeConfiguration<Journal>
    {
        public override void Configure(EntityTypeBuilder<Journal> builder)
        {
           base.Configure(builder);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(56);
            builder.Property(a => a.Abbreviation)
                .IsRequired()
                .HasMaxLength(8);
        }
    }
}
