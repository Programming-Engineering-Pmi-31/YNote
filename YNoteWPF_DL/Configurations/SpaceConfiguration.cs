using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YNoteWPF_DL.Entities;

namespace YNoteWPF_DL.Configurations
{
    class SpaceConfiguration : IEntityTypeConfiguration<SpaceEntity>
    {
        public void Configure(EntityTypeBuilder<SpaceEntity> builder)
        {
            builder.ToTable("Spaces");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.SpaceName).IsRequired();

            builder.Property(e => e.AuthorId).IsRequired();

            builder.Property(e => e.SpaceName).HasMaxLength(100);

            builder.HasOne(e => e.Author)
                .WithMany(author => author.Spaces)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
