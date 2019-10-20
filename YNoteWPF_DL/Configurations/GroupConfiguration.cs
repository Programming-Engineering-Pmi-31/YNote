using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YNoteWPF_DL.Entities;

namespace YNoteWPF_DL.Configurations
{
    class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.SpaceId).IsRequired();

            builder.HasOne(e => e.Space)
                .WithMany(space => space.Groups)
                .HasForeignKey(e => e.SpaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
