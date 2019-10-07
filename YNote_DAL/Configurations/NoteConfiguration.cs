using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YNote_DAL.Entities;

namespace YNote_DAL.Configurations
{
    class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.ToTable("Notes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationTime).IsRequired();

            builder.HasOne(e => e.Space)
                .WithMany(space => space.Notes)
                .HasForeignKey(e => e.SpaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Group)
                .WithMany(group => group.Notes)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.AssignedUser)
                .WithMany(user => user.Notes)
                .HasForeignKey(e => e.AssignedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
                
        }
    }
}
